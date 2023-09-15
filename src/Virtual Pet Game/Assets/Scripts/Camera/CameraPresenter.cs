using UnityEngine;
using System.Collections;

public class CameraPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] new PlayerCamera camera;

    void IPresenter.onModelStateChanged()
    {
        Debug.Log("Camera change to state isLocked = " + camera.isLocked);
    }

    public void SetLocked(bool isLocked)
    {
        camera.SetLocked(isLocked);
    }
}
