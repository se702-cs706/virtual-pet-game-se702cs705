using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] Transform orientation;
    private Camera cam;
    public bool isLocked { get; private set; }

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponent<Camera>();
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

        //Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void setGoodDoggo(bool active)
    {

        if (!active)
        {

            //Makes camera not see capsule doggo, makes it see good doggo
            cam.cullingMask |= 1 << LayerMask.NameToLayer("BetterDog");
            cam.cullingMask &= ~(1 << LayerMask.NameToLayer("CapsuleDog"));

        } else
        {

            //Makes camera not see good doggo, makes it see capsule doggo
            cam.cullingMask |= 1 << LayerMask.NameToLayer("CapsuleDog");
            cam.cullingMask &= ~(1 << LayerMask.NameToLayer("BetterDog"));

        }

    }
}
