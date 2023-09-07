using Unity.VisualScripting;
using UnityEngine;

namespace Interactable.Interactions
{
    public class PickUpAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] 
        string name;
        [SerializeField] 
        Interaction<PlayerController> action;
        private GameObject _selfRef;
        void Awake()
        {
            _selfRef = this.gameObject;
        }

        public override string GetName()
        {
            return name;
        }

        public override void Invoke(PlayerController controller)
        {
            controller.setAction(action);
            //remove self
            Destroy(_selfRef);
        }
    }
}
