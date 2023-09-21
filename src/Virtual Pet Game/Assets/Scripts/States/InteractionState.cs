using Interactable;
using PointOfInterestCode;

namespace States
{
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
            _interaction.InteractionStart(_manager);
        }
        
        public override IState onStateDuringUpdate()
        {
            _interaction.InteractionDuring();
            return null;
        }

        public override IState onGoalReached()
        {
            _interaction.InteractionEnd();
            return base.onGoalReached();
        }
    }
}