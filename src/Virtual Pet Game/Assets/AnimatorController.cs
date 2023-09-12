using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [Header("animator")] 
    [SerializeField] private Animator _animator;

    [SerializeField] float Speed = 0;
    [SerializeField] private DogState State = 0;

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", Speed);
        _animator.SetInteger("State", (int) State);
    }

    public void setSpeed(float speed)
    {
        this.Speed = speed;
    }
}
