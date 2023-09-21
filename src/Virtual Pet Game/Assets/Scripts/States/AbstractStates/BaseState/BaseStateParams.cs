using JetBrains.Annotations;

namespace States
{
    public class BaseStateParams : IStateParams
    {
        [CanBeNull] public IState _next;
        public DogState _state;
    }

}