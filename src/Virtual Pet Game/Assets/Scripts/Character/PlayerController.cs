using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactable;
using JetBrains.Annotations;
using PointOfInterestCode;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

/// <summary>
/// Provides the presenter the ability to control the player.
/// Also holds the player's state;
/// </summary>
public class PlayerController : MetricsTracker
{
    [Header("Presenter")]
    [SerializeField] IPresenter characterPresenter;

    // TODO: see if we can reference an interface instead.
    [Header("Deps")]
    [SerializeField] DogManager dogManager;
    [SerializeField] private PointOfInterest pointOfInterest;
    [SerializeField] float sitTime = 10;

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float groundDrag;

    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;
    bool readyToJump;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")]
    [SerializeField] float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Positions")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform headPosition;
    [SerializeField] private Transform headOrientation;
    
    [Header("Interactions")]
    //size of the sphere that checks for interactions
    [SerializeField] float interactionRadius;
    // range of the raycast that checks for interactions
    [SerializeField] float interactionRange;
    public bool isTargetingInteractable = false;
    
    
    [Header("ThrowBall")]
    [SerializeField] float throwForce;
    [SerializeField] GameObject BallObject;
    [SerializeField] private DogManager _manager;
    public bool hasBall = false;

    public Vector3 getPlayerOrientation()
    {
        return headOrientation.forward;
    }

    [Header("Raycast Layermaks")]
    [SerializeField] LayerMask layerMask;
    
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    // interactions with external objects
    public List<Interaction<PlayerController>> interactions { get; private set; }
    private GameObject lastTargetObj;
    public PlayerState playerState { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        playerState = PlayerState.Active;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        GetTarget();
        MovePlayer();
    }

    public void MovementInput(float vertialInput, float hotizontalInput)
    {
        this.verticalInput = vertialInput;
        this.horizontalInput = hotizontalInput;
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        else if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed;
            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
        }
    }

    public void Jump()
    {
        if (!readyToJump || !grounded)
        {
            return;
        }

        readyToJump = false;
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        Invoke(nameof(ResetJump), jumpCooldown);
    }

    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public void ChangeState(PlayerState newState)
    {
        playerState = newState;
        characterPresenter.onModelStateChanged();
    }

    private void GetTarget()
    {
        RaycastHit hit;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(headPosition.position, interactionRadius, headOrientation.forward, out hit, interactionRange,layerMask))
        {
            GameObject colliderGameObject = hit.collider.gameObject;

            if (colliderGameObject == lastTargetObj)
            {
                return;
            }


            // Check if targeting dog
            // FIXME: need a better way to identify whether targeting a dog
            bool isTargetingDog = colliderGameObject.CompareTag("Dog");
            bool isFixated = presenter.getIsFixated();
            //Debug.Log(gameObject);

            // If targeting dog (and was not previously), start fixation
            if (isTargetingDog && !isFixated)
            {
                presenter.StartFixation();
            }
            else if (!isTargetingDog && isFixated)
            {
                presenter.StopFixation();
            }

            lastTargetObj = colliderGameObject;

            IInteractable interactable = colliderGameObject.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                isTargetingInteractable = true;
                interactions = interactable.GetInteractions();
            }
        }
        else
        {
            isTargetingInteractable = false;
            interactions = null;
            lastTargetObj = null;

            // If not targeting dog anymore (but was before), stop fixation
            if (presenter.getIsFixated())
            {
                presenter.StopFixation();
            }
        }

        //CheckIsTargetingDog(hit.collider.gameObject);
    }

    /// <summary>
    /// Perform the interaction of index "i"
    /// </summary>
    /// <param name="i">index of interaction</param>
    /// <returns>
    /// True when the interaction exist.
    /// False when there is no such index.
    /// </returns>
    public bool Interact(int i)
    {
        if (interactions == null || interactions.Count - 1 < i)
        {
            return false;
        }

        // Log interaction metric
        presenter.LogInteraction(interactions[i].GetName());

        // nullable 
        interactions?[i].Invoke(this);
        return true;
    }

    /// <summary>
    /// Throw a ball as a predefined action
    /// </summary>
    public void ThrowBall()
    {
        if (!hasBall)
        {
            return;
        }
        
        //Instantiate(BallPrefab, headPosition.position + (headOrientation.forward * 0.2f), headOrientation.rotation);
        BallObject.SetActive(true);
        BallObject.GetComponent<PointOfInterest>().InterestLevel = 200;
        BallObject.transform.position = headPosition.position + (headOrientation.forward * 0.2f);
        BallObject.GetComponent<Rigidbody>().AddForce(headOrientation.forward * throwForce, ForceMode.Impulse);
        hasBall = false;
        Debug.Log("thrown ball");
    }
    
    /// <summary>
    /// Get the names of the interactions. Interactions should not be public to the presenter
    /// </summary>
    /// <returns>
    /// A list of interaction names. The index matches the interaction index
    /// </returns>
    public List<string> GetInteractionNames()
    {
        return interactions.Select(interaction => interaction.GetName()).ToList();
    }

    public bool HasInteractions()
    {
        return interactions != null;
    }


    public IEnumerator CallDog()
    {
        pointOfInterest.InterestLevel = 200;

        yield return new WaitForSeconds(1f);

        pointOfInterest.InterestLevel = 10;
    }
    
    public void CommandDogToSit()
    {
        dogManager.startStateAction(DogState.Sit, sitTime);
    }
}
