using TMPro;
using UnityEngine;

public class InteractionUIPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] PlayerController controller;

    [SerializeField] PromptController promptController;
    [SerializeField] RadialMenuController radialMenuController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!controller.isTargetingInteractable)
        {
            // Default case
            promptController.HideAll();
        } else
        {
            bool singleAction = controller.interactions.Count <= 1;

            if (singleAction)
            {
                promptController.ShowInteract();
            } else
            {
                promptController.ShowSelect();
            }
        }
    }

    public int GetInteractionIndex()
    {
        if (radialMenuController.isVisible)
        {
            return radialMenuController.GetInteractionIndex();
        }
        // Default case: first interaction
        return 0;
    }

    public void onModelStateChanged()
    {
        Debug.Log("Radial menu change to state: ");
    }
}
