using UnityEngine;

namespace States
{
    public class RunningToStateParams : BaseStateParams
    {
        public float _maxSpeed;
        public Transform _target;
        public float distance = 0;
    }
}