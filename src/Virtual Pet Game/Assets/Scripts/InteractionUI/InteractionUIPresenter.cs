using TMPro;
using UnityEngine;

public class InteractionUIPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PromptController promptController;

    public KeyBindings keyBindings;

    // Start is called before the first frame update
    void Start()
    {
        // Set keybinding text on Start, as this will never be changed.
        promptController.SetThrowBallKey(keyBindings.KeyThrowBall);
        promptController.SetSitKey(keyBindings.KeySit);
        promptController.SetComeBoyKey(keyBindings.KeyComeBoy);

        // Set default visibility
        promptController.SetVoiceCommandsVisible(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerController.isTargetingInteractable)
        {
            // Default case
            promptController.HideAll();
        } else
        {
            if (playerController.HasInteractions())
            {

                // Render according to what interaction is mapped to what key

                foreach (Interactable.Interaction<PlayerController> interaction in playerController.interactions)
                {
                    KeyCode key = keyBindings.GetInteractKeyCode(interaction.GetInteractKey());
                    string promptText = $"{interaction.GetName()} ({key})";

                    promptController.SetInteractVisible(interaction.GetInteractKey(), true);
                    promptController.SetInteractText(interaction.GetInteractKey(), promptText);
                }
            }
        }

        promptController.SetThrowBallVisible(playerController.hasBall);
    }

    public void SetVoiceCommandsVisible(bool isVisible)
    {
        promptController.SetVoiceCommandsVisible(isVisible);
    }

    public void onModelStateChanged()
    {
        
    }
}
