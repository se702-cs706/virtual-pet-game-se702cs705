using UnityEngine;

namespace PointOfInterestCode
{
    [RequireComponent(typeof(PointOfInterest))]
    public class BallPOI : DogInteraction
    {
        private DogManager _manager;
        
        public override void InteractionStart(IStateActions manager)
        {
            Debug.Log("int started");
            manager.setHolding(gameObject);
            Debug.Log("SHOULDA DISSAPEARED BITCH");
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