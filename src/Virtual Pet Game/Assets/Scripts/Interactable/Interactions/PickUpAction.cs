using UnityEngine;

namespace Interactable.Interactions
{
    public class PickUpAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] string name;
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
            controller.holdingBall = true;
            //remove self
            Destroy(_selfRef);
        }
    }
}
