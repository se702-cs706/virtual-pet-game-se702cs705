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

        // Update items in menu

        // TODO: check if menu items have changed, else don't clear and re-update

        radialMenuController.ClearSectors();

        int numSectors = playerController.interactions.Count;
        float deltaAngle = Mathf.PI * 2 / numSectors;

        Debug.Log(numSectors);

        for (int i = 0; i < numSectors; i++)
        {
            string text = playerController.interactions[i].GetName();
            float minAngle = deltaAngle * i;
            float maxAngle = deltaAngle * (i + 1);

            GameObject obj = new();
            obj.AddComponent<RadialMenuSector>();

            RadialMenuSector sector = obj.GetComponent<RadialMenuSector>();
            sector.Init(i, text, minAngle, maxAngle);

            radialMenuController.AddSector(sector);
            Debug.Log($"add {text} with range: {minAngle} - {maxAngle}");
        }
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
