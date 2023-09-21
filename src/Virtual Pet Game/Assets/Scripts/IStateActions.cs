using PointOfInterestCode;
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
    public float getEnergy();
    public void RestoreEnergy(float energy);
    public float getExcitement();
    public void RaiseExcitement(float excitement);
    public float getWalkSpeed();
    public float getRunSpeed();
    public float getSprintSpeed();
    public Transform getPlayerTransform();
    public GameObject getHolding();
    public void setHolding(GameObject gameObject);
}