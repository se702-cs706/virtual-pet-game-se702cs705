using PointOfInterestCode;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactable.Interactions
{
    public class PickUpAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] new string name;
        [SerializeField] InteractKey interactKey;
        [SerializeField] private PointOfInterest _pointOfInterest;

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
            controller.hasBall = true;
            _pointOfInterest.InterestLevel = -100;
            //remove self
            _selfRef.SetActive(false);
        }
    }
}
