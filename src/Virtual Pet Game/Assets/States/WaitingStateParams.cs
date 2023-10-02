using JetBrains.Annotations;
using UnityEngine;

namespace States
{
    public class WaitingStateParams : TimedStateParams
    {
        [CanBeNull] public Transform _lookAt;
        public new DogState _state = DogState.Idle;
    }
}