
/// <summary>
/// The interface the presenter calls when requiring a model deps
/// </summary>
public interface IManagerModel
{
    public void startStateAction(DogState state, float time);
}