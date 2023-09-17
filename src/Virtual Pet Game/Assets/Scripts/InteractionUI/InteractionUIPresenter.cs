using TMPro;
using UnityEngine;

public class InteractionUIPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PromptController promptController;

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

                // TODO: Render according to what interaction is mapped to what key

                switch (playerController.interactions.Count)
                {
                    case 1:
                        promptController.SetInteractVisible(1, true);
                        break;
                    case 2:
                        promptController.SetInteractVisible(1, true);
                        promptController.SetInteractVisible(2, true);
                        break;
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
