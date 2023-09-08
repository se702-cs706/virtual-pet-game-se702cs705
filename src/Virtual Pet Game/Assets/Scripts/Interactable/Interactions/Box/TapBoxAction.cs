using Unity.VisualScripting;
using UnityEngine;

namespace Interactable.Interactions
{
    public class TapBoxAction : Interaction<PlayerController>
    {
        [Header("Name")]
        [SerializeField] new string name;

        public override string GetName()
        {
            return name;
        }

        public override void Invoke(PlayerController controller)
        {
            Debug.Log("Tap box");
        }
    }
}
