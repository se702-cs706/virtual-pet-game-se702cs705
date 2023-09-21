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
                    _maxSpeed = _manager.getRunSpeed(),
                    _next = next,
                    distance = _manager.PointOfInterest.InteractionDistance,
                    _target = _manager.PointOfInterest.transform,
                });
            }

            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = 5,
            });;
        }

        public static IState GetZoomiesState(IStateActions _manager, StateFactory _stateFactory)
        {
            var rand = Random.Range(7, 14);
            
            return _stateFactory.BuildState<WanderingState, WanderingStateParams>(new WanderingStateParams()
            {
                _time = rand,
                _maxSpeed = _manager.getSprintSpeed(),
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
            });
        }

        public static IState GetActionState( StateFactory _stateFactory, DogState state, float time, IState next = null)
        {
            return _stateFactory.BuildState<ActionState, TimedStateParams>(new TimedStateParams()
            {
                _state = state,
                _time = time,
                _next = next,
            });
        }
        
        public static IState GetRunToSequence(StateFactory _stateFactory, float maxSpeed, float distance, float waitingTime, Transform target, IState next = null)
        {
            var nextAction = _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = waitingTime,
                _next = next,
            });
            
            return _stateFactory.BuildState<RunningToState, RunningToStateParams>(new RunningToStateParams()
            {
                _maxSpeed = maxSpeed,
                distance = distance,
                _target = target,
                _next = nextAction,
            });
        }

        public static IState GetPlayerActionState(StateFactory _stateFactory, DogState state, float actionTime, float waitingTime)
        {
            var nextAction = _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = waitingTime,
            });
            
            return _stateFactory.BuildState<ActionState, TimedStateParams>(new TimedStateParams()
            {
                _time = actionTime,
                _next = nextAction,
            }); 
        }
    }
}