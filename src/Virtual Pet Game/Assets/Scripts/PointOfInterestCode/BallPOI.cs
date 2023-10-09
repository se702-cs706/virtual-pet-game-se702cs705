using UnityEngine;

namespace PointOfInterestCode
{
    [RequireComponent(typeof(PointOfInterest))]
    public class BallPOI : DogInteraction
    {
        private DogManager _manager;
        
        public override void InteractionStart(IStateActions manager)
        {
            manager.setHolding(gameObject);
            GetComponent<PointOfInterest>().InterestLevel = -100;
            gameObject.SetActive(false);
        }

        public override void InteractionDuring()
        {
        }

        public override void InteractionEnd()
        {
        }
    }
}