using System.Collections;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

public class ThrowAction : Interaction<PlayerController>
{
    [Header("Name")]
    [SerializeField] string actionName;
    [SerializeField] GameObject ThrowPrefab;
    
    public override string GetName()
    {
        return actionName;
    }

    public override void Invoke(PlayerController controller)
    {
        var newBall = Instantiate(ThrowPrefab,controller.transform.position,Quaternion.identity);
        var rb = newBall.GetComponent<Rigidbody>();
        rb.AddForce(controller.getPlayerOrientation());
    }
}
