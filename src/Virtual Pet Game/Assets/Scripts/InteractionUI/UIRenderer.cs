using TMPro;
using UnityEngine;

public class UIRenderer : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    [SerializeField] GameObject interactPrompt;
    [SerializeField] GameObject radialMenu;

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
            interactPrompt.GetComponent<TextMeshProUGUI>().alpha = 0;
            radialMenu.SetActive(false);
        } else
        {
            bool singleAction = controller.interactions.Count <= 1;

            interactPrompt.GetComponent<TextMeshProUGUI>().alpha = singleAction ? 1 : 0;
            radialMenu.SetActive(!singleAction);
        }
    }
}
