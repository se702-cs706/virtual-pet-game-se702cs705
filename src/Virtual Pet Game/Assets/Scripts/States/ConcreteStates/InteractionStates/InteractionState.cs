using Interactable;
using PointOfInterestCode;
using States;
using UnityEngine;

/// <summary>
/// State that changes state of the world around
/// </summary>
public class InteractionState : ActionState, InitializableState<InteractionStateParams>
{
    private IDogInteraction _interaction;

    public void OnStateBuild(InteractionStateParams param, DogManager manager, AgentController controller)
    {
        _interaction = param._interaction;
        base.OnStateBuild(param,manager,controller);
    }

    public override void onStateEnterChild()
    {
        Debug.Log(_interaction);
        _interaction.InteractionStart(_manager);
        base.onStateEnterChild();
    }
    
    public override IState onStateDuringUpdate()
    {
        _interaction.InteractionDuring();
        
        if (_manager.GetPointOfInterest().InterestLevel > 100)
        {
            return StatesHelper.GetPOIActionStates(_manager, _stateFactory);
        }
        
        return null;
    }

    public override IState onGoalReached()
    {
        _interaction.InteractionEnd();
        
        if (_next != null)
        {
            return base.onGoalReached();
        }
        
        if (_manager.getEnergy() > 7)
        {
            return StatesHelper.GetZoomiesState(_manager, _stateFactory);
        }
        
        return _next;
    }
}