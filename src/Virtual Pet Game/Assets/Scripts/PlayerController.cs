using System.Collections;
using System.Collections.Generic;
using Interactable;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Provides the presenter the ability to control the player.
/// Also holds the player's state;
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Presenter")]
    [SerializeField] IPresenter characterPresenter;

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

    [Header("Positions")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform headPosition;
    [SerializeField] Transform headOrientation;

    [Header("Raycast Layermaks")]
    [SerializeField] LayerMask layerMask;
    
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    // interactions with external objects
    private List<Interaction<PlayerController>> interactions;
    // actions within the player
    [CanBeNull] private Interaction<PlayerController> action;
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

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed;
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    public void Jump()
    {
        if (!readyToJump || !grounded)
        {
            return;
        }

        readyToJump = false;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        Invoke(nameof(ResetJump), jumpCooldown);
    }

    private void ResetJump()
    {
        readyToJump = true;
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
        if (Physics.SphereCast(headPosition.position, 1, headOrientation.forward, out hit, 3,layerMask))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (gameObject == lastTargetObj)
            {
                return;
            }

            lastTargetObj = gameObject;
            IInteractable interactable = gameObject.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                interactions = interactable.GetInteractions();
            }
        }
        else
        {
            interactions = null;
            lastTargetObj = null;
        }
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
        if (interactions.Count < i)
        {
            return false;
        }
        // nullable 
        interactions?[i].Invoke(this);
        return true;
    }

    /// <summary>
    /// Performs the current action of the player.
    /// </summary>
    /// <returns>
    /// True when there is an action to perform.
    /// False when there is not.
    /// </returns>
    public bool PerformAction()
    {
        if (action)
        {
            action.Invoke(this);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public List<string> GetInteractionNames()
    {
        List<string> names = new List<string>();
        foreach (var interaction in interactions)
        {
            names.Add(interaction.GetName());
        }

        return names;
    }
}
