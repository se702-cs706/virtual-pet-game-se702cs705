using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        if (!controller.isTargetingInteractable)
        {
            // Default case
            interactPrompt.SetActive(false);
            radialMenu.SetActive(false);
        } else
        {
            bool singleAction = controller.interactions.Count <= 1;

            interactPrompt.SetActive(singleAction);
            radialMenu.SetActive(!singleAction);
        }
    }
}
