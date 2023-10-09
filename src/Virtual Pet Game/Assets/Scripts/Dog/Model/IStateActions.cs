using PointOfInterestCode;
using UnityEngine;

/// <summary>
/// The interface the state calls internally within the state manager
/// </summary>
public interface IStateActions
{
    public PointOfInterest GetPointOfInterest();
    public void setState(DogState state);
    public void resetTime();
    public float getActionTime();
    public DogState getState();
    public float getEnergy();
    public void RestoreEnergy(float energy);
    public float getExcitement();
    public void setExcitement(float excitement);
    public float getWalkSpeed();
    public float getRunSpeed();
    public float getSprintSpeed();
    public PointOfInterest getPlayerPoi();
    public GameObject getHolding();
    public void setHolding(GameObject gameObject);
    public void DropHolding();
}