using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [Header("animator")] 
    [SerializeField] private Animator _animator;

    [SerializeField] float Speed = 0;
    [SerializeField] private float runSpeedMultiplier;
    [FormerlySerializedAs("State")] [SerializeField] private DogState state = 0;
    [SerializeField] private float drift = 0;

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", Speed);
        _animator.SetFloat("runSpeed", Speed * runSpeedMultiplier);
        _animator.SetInteger("State", (int) state);
        _animator.SetFloat("Drift", drift);
    }

    public void setSpeed(float speed)
    {
        this.Speed = speed;
    }
    
    public void setDrift(float drift)
    {
        this.drift = drift;
    }

    public void setState(DogState state)
    {
        this.state = state;
    }
}
