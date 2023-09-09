using UnityEngine;

/// <summary>
/// A View component in the MVP pattern.
/// Used for interpreting inputs from keyboards.
/// </summary>
public class InputView : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode KeyForward;
    public KeyCode KeyBackward;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;
    public KeyCode KeyJump;

    [Header("Interaction")] 
    public KeyCode KeyInteract;
    public KeyCode KeyThrowBall;
    
    [Header("Presenters")]
    public CharacterPresenter characterPresenter;
    public InteractionUIPresenter interactionUIPresenter;

    public void Update()
    {
        // key press action
        if(Input.GetKey(KeyForward) ||
            Input.GetKey(KeyBackward) || 
            Input.GetKey(KeyLeft) ||
            Input.GetKey(KeyRight))
        {
            characterPresenter.MovementKeyPressed(
                        Input.GetKey(KeyForward), 
                        Input.GetKey(KeyBackward), 
                        Input.GetKey(KeyLeft), 
                        Input.GetKey(KeyRight));
        }
        else
        {
            characterPresenter.MovementKeyReleased();
        }
        
        // jump key pressed
        if(Input.GetKeyDown(KeyJump))
        {
            characterPresenter.JumpKeyPressed();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (interactionUIPresenter.IsMenuOpen())
                interactionUIPresenter.CloseMenu();
        }
        
        // interact key pressed
        if (Input.GetKeyDown(KeyInteract))
        {
            if (interactionUIPresenter.IsSingleAction())
            {
                characterPresenter.InteractKeyPressed(0);
            }
            else
            {
                if (interactionUIPresenter.IsMenuOpen())
                {
                    // Allow click to select interaction index
                    int index = interactionUIPresenter.GetInteractionIndex();
                    characterPresenter.InteractKeyPressed(index);
                }
                else
                {
                    interactionUIPresenter.OpenMenu();
                    // Lock camera
                }
            }
        }

        // throw ball key pressed
        if (Input.GetKeyDown(KeyThrowBall))
        {
            characterPresenter.ThrowBallKeyPressed();
        }
    }
}
