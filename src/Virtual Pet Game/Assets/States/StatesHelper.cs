using UnityEngine;

namespace States
{
    public class StatesHelper
    {
        public static IState GetPOIActionStates(IStateActions _manager, StateFactory _stateFactory)
        {
            if (_manager.PointOfInterest != null)
            {
                IState next = null;
                if (_manager.PointOfInterest.InterestType == InterestType.food)
                {
                    next = _stateFactory.BuildState<ActionState, TimedStateParams>(new TimedStateParams()
                    {
                        _state = DogState.Eat,
                        _time = _manager.PointOfInterest.InterestTime,
                    });
                }
                else if (_manager.PointOfInterest.InterestType == InterestType.play)
                {
                    next = null;
                }
                else if (_manager.PointOfInterest.InterestType == InterestType.rest)
                {
                    next = _stateFactory.BuildState<ActionState, TimedStateParams>(new TimedStateParams()
                    {
                        _state = DogState.Rest,
                        _time = _manager.PointOfInterest.InterestTime
                    });;
                }
            
                _manager.PointOfInterest.canBeUsed = false;
                return _stateFactory.BuildState<RunningToState, RunningToStateParams>(new RunningToStateParams()
                {
                    _maxSpeed = 5,
                    _next = next,
                    _target = _manager.PointOfInterest.transform.position,
                });
            }

            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = 5,
            });;
        }

        public static IState GetZoomiesState(StateFactory _stateFactory)
        {
            var rand = Random.Range(7, 14);
            
            return _stateFactory.BuildState<WanderingState, WanderingStateParams>(new WanderingStateParams()
            {
                _time = rand,
                _maxSpeed = 7,
            });
        }
        
        public static IState GetWaitingForPlayerActionState(StateFactory _stateFactory, Transform _lookAt)
        {
            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _lookAt = _lookAt,
                _time = 7,
            });;
        }
        
        public static IState GetIdleState(StateFactory _stateFactory)
        {
            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = 3,
            });;
        }
    }
}