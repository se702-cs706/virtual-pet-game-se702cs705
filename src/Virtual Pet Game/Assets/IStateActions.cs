using UnityEngine;

public interface IStateActions
{
    public void setState(DogState state);
    public void resetTime();
    public float getActionTime();
    public DogState getState();
    public void setLookAt(Transform lookAt);
}