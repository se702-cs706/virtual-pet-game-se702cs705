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
            if (playerController.HasInteractions() && IsSingleAction())
            {
                promptController.SetInteractVisible(true);
            } else
            {
                //promptController.SetSelectVisible(!IsMenuOpen());
            }
        }

        promptController.SetThrowBallVisible(playerController.hasBall);
    }

    public bool IsSingleAction()
    {
        return playerController.interactions.Count <= 1;
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
