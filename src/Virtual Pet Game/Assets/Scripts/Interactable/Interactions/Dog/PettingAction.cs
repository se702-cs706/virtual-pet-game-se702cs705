using System.Collections;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

public class PettingAction : Interaction<PlayerController>
{
    [Header("Name")]
    [SerializeField] new string name;
    [SerializeField] InteractKey interactKey;
    [SerializeField] private DogManager _dogManager;
    [SerializeField] private float duration;

    private GameObject _selfRef;

    void Awake()
    {
        _selfRef = this.gameObject;
    }

    public override InteractKey GetInteractKey()
    {
        return interactKey;
    }

    public override string GetName()
    {
        return name;
    }

    public override void Invoke(PlayerController controller)
    {
        _dogManager.startStateAction(DogState.Pet, duration);
        // TODO add player action
    }
}
