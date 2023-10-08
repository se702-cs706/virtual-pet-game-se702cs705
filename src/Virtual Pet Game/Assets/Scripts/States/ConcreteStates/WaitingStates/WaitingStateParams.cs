using JetBrains.Annotations;
using PointOfInterestCode;
using UnityEngine;

namespace States
{
    public class WaitingStateParams : TimedStateParams
    {
        [CanBeNull] public PointOfInterest _lookAt;
        public new DogState _state = DogState.Idle;
    }
}