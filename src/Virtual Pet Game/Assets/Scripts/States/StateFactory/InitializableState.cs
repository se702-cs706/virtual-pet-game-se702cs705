namespace States
{
    public interface InitializableState<T> where T : IStateParams
    {
        /// <summary>
        /// Used by the StateFactory to build the state
        /// </summary>
        /// <param name="param"></param>
        public void OnStateBuild(T param, DogManager manager, AgentController controller);
    }
}