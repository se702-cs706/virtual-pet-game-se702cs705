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
                    promptController.SetInteractVisible(interaction.GetInteractKey(), true);

                    KeyCode key = keyBindings.GetInteractKeyCode(interaction.GetInteractKey());
                    string promptText = $"{interaction.GetName()} ({key})";

                    promptController.SetInteractText(interaction.GetInteractKey(), promptText);
                }
            }
        }

        promptController.SetThrowBallVisible(playerController.hasBall);
    }

    public int GetInteractionIndex()
    {
        // Default case: first interaction
        return 0;
    }

    public void onModelStateChanged()
    {
        
    }
}
