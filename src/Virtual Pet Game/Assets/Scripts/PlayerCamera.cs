using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] Transform orientation;
    public bool isLocked { get; private set; }

    float xRotation;
    float yRotation;

    private void Start()
    {
        SetLocked(false);
        UpdateCursorMode();
    }

    private void Update()
    {
        if (!isLocked)
        {
            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        
    }

    public void SetLocked(bool isLocked)
    {
        this.isLocked = isLocked;
        UpdateCursorMode();
    }

    private void UpdateCursorMode()
    {
        Cursor.visible = isLocked;

        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
