using UnityEngine;

/// <summary>
/// The interface the state calls internally within the state manager
/// </summary>
public interface IStateActions
{
    public PointOfInterest PointOfInterest { get; set; }
    public void setState(DogState state);
    public void resetTime();
    public float getActionTime();
    public DogState getState();
    public void setLookAt(Transform lookAt);
}