using UnityEngine;

namespace Interactable
{
    /// <summary>
    /// An interaction to be performed by a character
    /// </summary>
    [System.Serializable]
    public abstract class Interaction<T> : MonoBehaviour
    {
        public abstract string GetName();
        public abstract void Invoke(T controller);
    }
}
