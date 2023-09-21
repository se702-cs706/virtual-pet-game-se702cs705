
namespace PointOfInterestCode
{
    public interface IDogInteraction
    {
        public void InteractionStart(IStateActions manager);

        public void InteractionDuring();

        public void InteractionEnd();
    }
}