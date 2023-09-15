using TMPro;
using UnityEngine;

public class InteractionUIPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PromptController promptController;
    [SerializeField] RadialMenuController radialMenuController;

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
                promptController.SetSelectVisible(!IsMenuOpen());
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
        if (radialMenuController.isVisible)
        {
            return radialMenuController.GetInteractionIndex();
        }
        // Default case: first interaction
        return 0;
    }

    public void onModelStateChanged()
    {
        Debug.Log("Radial menu change to state isVisible = " + radialMenuController.isVisible);
    }

    public void OpenMenu()
    {
        radialMenuController.Show();
    }

    public void CloseMenu()
    {
        radialMenuController.Hide();
    }

    public bool IsMenuOpen()
    {
        return radialMenuController.isVisible;
    }
}
