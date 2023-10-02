namespace States.ConcreteStates.DropHoldingState
{
    public class DropHoldingActionState : BaseState, InitializableState<BaseStateParams>
    {
        public override void onStateEnterChild()
        {
            if (_manager.getHolding() != null)
            {
                _manager.DropHolding();
            }
        }

        public override IState onStateUpdate()
        {
            return _next;
        }

        public override void onStateExit()
        {
        }
    }
}