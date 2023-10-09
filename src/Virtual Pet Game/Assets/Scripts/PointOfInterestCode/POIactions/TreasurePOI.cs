using UnityEngine;

namespace PointOfInterestCode.POIactions
{
    [RequireComponent(typeof(PointOfInterest))]
    public class TreasurePOI: DogInteraction
    {
        private IStateActions _manager;
        private PointOfInterest _pointOfInterest;
        [SerializeField] private GameObject treasure;
        [SerializeField] private ParticleSystem _particleSystem;

        public override void InteractionStart(IStateActions manager)
        {
            _manager = manager;
            _pointOfInterest = GetComponent<PointOfInterest>();
            manager.setState(DogState.Dig);
            _particleSystem.Play();
            
        }

        public override void InteractionDuring()
        {
        }

        public override void InteractionEnd()
        {
            _particleSystem.Stop();
            _pointOfInterest.canBeUsed = false;

            if (_manager.getHolding() != null && treasure == null)
            {
                // bury treasure
                treasure = _manager.getHolding();
                _manager.setHolding(null);
            }
            else if (_manager.getHolding() == null && treasure != null)
            {
                //reveal treasure
                treasure.SetActive(true);
                treasure.transform.position = transform.position + Vector3.up * 0.3f;
                treasure.GetComponent<PointOfInterest>().InterestLevel = 150;
            }
        }
    }
}