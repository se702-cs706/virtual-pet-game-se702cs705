using UnityEngine;

namespace PointOfInterestCode.POIactions
{
    [RequireComponent(typeof(PointOfInterest))]
    public class DogBowlPOI : DogInteraction
    {
        private IStateActions _manager;
        private PointOfInterest _pointOfInterest;
        private float sTime;
        [SerializeField] private float RestoreRate;

        public override void InteractionStart(IStateActions manager)
        {
            sTime = 1;
            _manager = manager;
            _pointOfInterest = GetComponent<PointOfInterest>();
            manager.setState(DogState.Eat);
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
            _pointOfInterest.canBeUsed = false;
            //TODO make bowl empty
        }
    }
}