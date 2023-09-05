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
    public PlayerMovement _playerMovement;


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

    }

    public void JumpKeyPressed()
    {

    }
}
