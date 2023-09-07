using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public interface IInteractable
    {
        public List<Interaction<PlayerController>> GetInteractions();
    }
}
