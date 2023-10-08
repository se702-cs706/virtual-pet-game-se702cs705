using UnityEngine;

namespace PointOfInterestCode.POIactions
{
    [RequireComponent(typeof(PointOfInterest))]
    public class DogBowlPOI : DogInteraction
    {
        private Vector3 initialPos;
        public int maxYPosition = 0;
        private IStateActions _manager;
        private PointOfInterest _pointOfInterest;
        private float sTime;
        [SerializeField] private float RestoreRate;
        [SerializeField] private GameObject food;

        public override void InteractionStart(IStateActions manager)
        {
            sTime = 1;
            _manager = manager;
            _pointOfInterest = GetComponent<PointOfInterest>();
            manager.setState(DogState.Eat);
            initialPos = food.transform.position= new Vector3(0,0,0);
        }

        public override void InteractionDuring()
        {
            sTime -= Time.deltaTime;
            if (sTime <= 0)
            {
                sTime++;
                _manager.RestoreEnergy(RestoreRate);
                food.transform.position = new Vector3(0, 0f, 0);
                
            }
        }

        public override void InteractionEnd()
        {
            _pointOfInterest.canBeUsed = false;
            //TODO make bowl empty

            food.transform.position = new Vector3(0, -0.07f, 0);

            


        }
        private void Update()
        {
            if (food.transform.position.y <= maxYPosition)
            {

                food.transform.Translate(Vector3.up * Time.deltaTime);
                //food.transform.position = initialPos;
            }
        }

    }
}