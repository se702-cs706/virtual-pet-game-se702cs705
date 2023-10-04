using System.Collections;
using System.Collections.Generic;
using PointOfInterestCode;
using UnityEngine;

public class DogBedPOI : DogInteraction
{
    private IStateActions _manager;
    private PointOfInterest _pointOfInterest;
    private float sTime;
    [SerializeField] private float RestoreRate;

    public override void InteractionStart(IStateActions manager)
    {
        _manager = manager;
        _pointOfInterest = GetComponent<PointOfInterest>();
        _manager.setState(DogState.Rest);
    }

    public override void InteractionDuring()
    {
        sTime -= Time.deltaTime;
        if (sTime <= 0)
        {
            sTime++;
            _manager.RestoreEnergy(RestoreRate);
        }
    }

    public override void InteractionEnd()
    {
        throw new System.NotImplementedException();
    }
}
