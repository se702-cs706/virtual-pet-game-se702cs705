using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Presenter component in the MVP,
/// Takes care of state change in character and moving the character RB.
/// </summary>
public class CharacterPresenter : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovementKeyPressed(bool forward, bool back, bool left, bool right)
    {
        float vertialInput = 0;
        float hotizontalInput = 0;
        if (forward && !back)
        {
            vertialInput = 1;
        }
        else if(!forward && back)
        {
            vertialInput = -1;
        }

        if (right && !left)
        {
            hotizontalInput = 1;
        }
        else if (!right && left)
        {
            hotizontalInput = -1;
        }

        playerMovement.MovementInput(vertialInput, hotizontalInput);
    }

    public void MovementKeyReleased()
    {
        playerMovement.MovementInput(0,0);
    }

    public void JumpKeyPressed()
    {
        playerMovement.Jump();
    }
}
