using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// State interface for defining a state
/// </summary>
public interface IState
{
    /// <summary>
    /// Called upon entering the new state
    /// </summary>
    public void onStateEnter();
    
    /// <summary>
    /// Called every update in the state manager of the state pattern.
    /// </summary>
    /// <returns> The exit state if the exit condition is met</returns>
    public IState onStateUpdate();
    
    /// <summary>
    /// Called upon exiting this state
    /// </summary>
    public void onStateExit();
}
