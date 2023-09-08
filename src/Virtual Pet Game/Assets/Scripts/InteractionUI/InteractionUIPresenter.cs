using TMPro;
using UnityEngine;

public class InteractionUIPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] PlayerController controller;

    [SerializeField] InteractPromptController interactPromptController;
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
            interactPromptController.Hide();
            radialMenuController.Hide();
        } else
        {
            bool singleAction = controller.interactions.Count <= 1;

            interactPromptController.SetVisible(singleAction);
            radialMenuController.SetVisible(!singleAction);
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
