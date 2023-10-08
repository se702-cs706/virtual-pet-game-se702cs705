using UnityEngine;

namespace PointOfInterestCode.POIactions
{
    public class PlayerPOI : DogInteraction
    {        
        private IStateActions _manager;
        private PointOfInterest _pointOfInterest;

        public override void InteractionStart(IStateActions manager)
        {
            _manager = manager;
            _pointOfInterest = GetComponent<PointOfInterest>();
            manager.setState(DogState.Idle);
        }

        public override void InteractionDuring()
        {
        }

        public override void InteractionEnd()
        {
        }
    }
}