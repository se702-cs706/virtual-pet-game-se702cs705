using UnityEngine;

/// <summary>
/// A View component in the MVP pattern.
/// Used for interpreting inputs from keyboards.
/// </summary>
public class InputView : MonoBehaviour
{
    public KeyBindings keyBindings;

    [Header("Presenters")]
    public CharacterPresenter characterPresenter;
    public InteractionUIPresenter interactionUIPresenter;
    public CameraPresenter cameraPresenter;

    private void Start()
    {
        interactionUIPresenter.keyBindings = keyBindings;
    }

    public void Update()
    {
        // key press action
        if(Input.GetKey(keyBindings.KeyForward) ||
            Input.GetKey(keyBindings.KeyBackward) || 
            Input.GetKey(keyBindings.KeyLeft) ||
            Input.GetKey(keyBindings.KeyRight))
        {
            characterPresenter.MovementKeyPressed(
                        Input.GetKey(keyBindings.KeyForward), 
                        Input.GetKey(keyBindings.KeyBackward), 
                        Input.GetKey(keyBindings.KeyLeft), 
                        Input.GetKey(keyBindings.KeyRight));
        }
        else
        {
            characterPresenter.MovementKeyReleased();
        }
        
        // jump key pressed
        if(Input.GetKeyDown(keyBindings.KeyJump))
        {
            characterPresenter.JumpKeyPressed();
        }

        if (characterPresenter.HasInteractions())
        {
            if (Input.GetKeyDown(keyBindings.KeyInteract1)) characterPresenter.Pressed(InteractKey.Interact1);
            if (Input.GetKeyDown(keyBindings.KeyInteract2)) characterPresenter.Pressed(InteractKey.Interact2);
            if (Input.GetKeyDown(keyBindings.KeyInteract3)) characterPresenter.Pressed(InteractKey.Interact3);
        }

        // throw ball key pressed
        if (Input.GetKeyDown(keyBindings.KeyThrowBall))
        {
            characterPresenter.ThrowBallKeyPressed();
        }
    }
}
