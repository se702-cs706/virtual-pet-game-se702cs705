using UnityEngine;

public interface IStateActions
{
    public Transform PointOfInterest { get; set; }
    public void setState(DogState state);
    public void resetTime();
    public float getActionTime();
    public DogState getState();
    public void setLookAt(Transform lookAt);
}