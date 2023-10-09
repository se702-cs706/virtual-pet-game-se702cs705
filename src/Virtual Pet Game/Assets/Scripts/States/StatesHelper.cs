using PointOfInterestCode;
using States.ConcreteStates.DropHoldingState;
using UnityEngine;

namespace States
{
    /// <summary>
    /// A Helper method for creating states and sequences easily.
    /// This class uses state factory to make states.
    /// This should be the only place where a state factory is used.
    /// </summary>
    public class StatesHelper
    {
        public static IState GetPOIActionStates(IStateActions _manager, StateFactory _stateFactory)
        {
            var pointOfInterest = _manager.GetPointOfInterest();
            if (pointOfInterest != null)
            {
                IState next = null;
                if (pointOfInterest.interaction != null)
                {
                    // dog takes ball and runs back to player
                    IState next2 = null;
                    if (pointOfInterest.CompareTag("Ball"))
                    {
                        next2 = GetRunToPlayerSequence(_stateFactory, _manager.getRunSpeed(), _manager.getPlayerPoi(),
                            lookAt: _manager.getPlayerPoi());
                    }
                    
                    next = _stateFactory.BuildState<InteractionState, InteractionStateParams>(
                    new InteractionStateParams()
                    {
                        _next = next2,
                        _interaction = pointOfInterest.interaction,
                        _time = pointOfInterest.InterestTime,
                    });
                }
                else if(pointOfInterest.CompareTag("Player"))
                {
                    next = _stateFactory.BuildState<WaitingState, WaitingStateParams>(
                        new WaitingStateParams()
                        {
                            _time = pointOfInterest.InterestTime,
                            _lookAt = pointOfInterest,
                        });
                }
                
                return _stateFactory.BuildState<RunningToState, RunningToStateParams>(new RunningToStateParams()
                {
                    _maxSpeed = _manager.getRunSpeed(),
                    _next = next,
                    distance = pointOfInterest.InteractionDistance,
                    _target = pointOfInterest.transform,
                });
            }

            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = 5,
            });;
        }

        public static IState GetRunToPOIActionSequence(IStateActions _manager, StateFactory _stateFactory, PointOfInterest pointOfInterest)
        {
            var next = _stateFactory.BuildState<InteractionState, InteractionStateParams>(
                new InteractionStateParams()
                {
                    _interaction = pointOfInterest.interaction,
                    _time = pointOfInterest.InterestTime,
                });
            
            return _stateFactory.BuildState<RunningToState, RunningToStateParams>(new RunningToStateParams()
            {
                _maxSpeed = _manager.getRunSpeed(),
                _next = next,
                distance = pointOfInterest.InteractionDistance,
                _target = pointOfInterest.transform,
            });
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
        
        public static IState GetWaitingForPlayerActionState(StateFactory _stateFactory, PointOfInterest _lookAt)
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
        
        public static IState GetRunToSequence(StateFactory _stateFactory, float maxSpeed, float distance, 
            float waitingTime, Transform target, IState next = null, PointOfInterest lookAt = null)
        {
            var nextAction = _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _lookAt = lookAt,
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
        
        public static IState GetRunToPlayerSequence(StateFactory _stateFactory, float maxSpeed, 
            PointOfInterest playerPointOfInterest, IState next = null, PointOfInterest lookAt = null)
        {
            var nextAction2 = _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _lookAt = lookAt,
                _time = playerPointOfInterest.InterestTime,
                _next = next,
            });

            var nextAction1 = _stateFactory.BuildState<DropHoldingActionState, BaseStateParams>(new BaseStateParams()
            {
                _next = nextAction2,
                _state = DogState.Idle,
            });
            
            return _stateFactory.BuildState<RunningToState, RunningToStateParams>(new RunningToStateParams()
            {
                _maxSpeed = maxSpeed,
                distance = playerPointOfInterest.InteractionDistance,
                _target = playerPointOfInterest.transform,
                _next = nextAction1,
            });
        }

        public static IState GetPlayerActionState(StateFactory _stateFactory, DogState state, float actionTime, float waitingTime, PointOfInterest lookAt = null)
        {
            var nextAction = _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _lookAt = lookAt,
                _time = waitingTime,
            });
            
            return _stateFactory.BuildState<ActionState, TimedStateParams>(new TimedStateParams()
            {
                _state = state,
                _time = actionTime,
                _next = nextAction,
            }); 
        }
    }
}