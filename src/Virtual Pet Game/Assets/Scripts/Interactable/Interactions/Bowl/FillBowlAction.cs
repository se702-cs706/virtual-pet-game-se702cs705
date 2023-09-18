using Unity.VisualScripting;
using UnityEngine;

namespace Interactable.Interactions
{
    public class FillBowlAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] 
        new string name;
        [SerializeField] 
        Interaction<PlayerController> action;
        private GameObject _selfRef;
        private BowlController bowlController;
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
            bowlController.ChangeState(BowlState.Filled);
            
            //remove self
            Destroy(_selfRef);
        }
    }
}
