using Unity.VisualScripting;
using UnityEngine;

namespace Interactable.Interactions
{
    public class PickUpAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] new string name;
        [SerializeField] InteractKey interactKey;

        [SerializeField] Interaction<PlayerController> action;

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
            //remove self
            Destroy(_selfRef);
        }
    }
}
