using UnityEngine;

namespace PointOfInterestCode
{
    [RequireComponent(typeof(PointOfInterest))]
    public class BallPOI : MonoBehaviour, IDogInteraction
    {
        private DogManager _manager;
        
        public void InteractionStart(IStateActions manager)
        {
            manager.setHolding(gameObject);
        }

        public void InteractionDuring()
        {
            throw new System.NotImplementedException();
        }

        public void InteractionEnd()
        {
            GetComponent<PointOfInterest>().InterestLevel = -100;
            gameObject.SetActive(false);
        }
    }
}