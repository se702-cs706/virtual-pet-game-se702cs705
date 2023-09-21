using UnityEngine;

namespace PointOfInterestCode.POIactions
{
    public class DogBowlPOI : DogInteraction
    {
        private IStateActions _manager;
        private float sTime;
        [SerializeField] private float RestoreRate;

        public override void InteractionStart(IStateActions manager)
        {
            sTime = 1;
            _manager = manager;
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
            //TODO make bowl empty
        }
    }
}