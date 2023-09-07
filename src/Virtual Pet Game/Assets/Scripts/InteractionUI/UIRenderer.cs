using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRenderer : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    [SerializeField] GameObject interactPrompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactPrompt.SetActive(controller.isTargetingInteractable);
    }
}
