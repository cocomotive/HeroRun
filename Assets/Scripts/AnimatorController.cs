using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController 
{
    private Animator _animator;


    public AnimatorController(Animator animator)
    {
        _animator = animator;
    }
    

    public void PlayIdle(bool Idle)
    {
        _animator.SetBool("Idle", Idle);
    }

    public void PlayRun(bool Run)
    {
        _animator.SetBool("Running", Run);
    }
}
