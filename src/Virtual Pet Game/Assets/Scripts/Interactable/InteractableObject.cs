using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class InteractableObject : MonoBehaviour,IInteractable
    {
        [Header("Interactions")]
        [SerializeField] List<Interaction<PlayerController>> _interactions;

        public List<Interaction<PlayerController>> GetInteractions()
        {
            return _interactions;
        }
    }
}
