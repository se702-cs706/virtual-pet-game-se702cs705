using UnityEngine;

namespace PointOfInterestCode
{
    public abstract class DogInteraction : MonoBehaviour, IDogInteraction
    {
        public abstract void InteractionStart(IStateActions manager);

        public abstract void InteractionDuring();

        public abstract void InteractionEnd();
    }
}