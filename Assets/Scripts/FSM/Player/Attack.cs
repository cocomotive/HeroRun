using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    FiniteStateMachine<PlayerStates> _FSM;
    //Transform _transform;
    //Controller _myController;
    Animator _animator;
    //float _speed;
    //float _rotationSpeed;

    public Attack(FiniteStateMachine<PlayerStates> FSM, Animator animator)
    {
        _FSM = FSM;
        _animator = animator;
    }

    public void OnStart()
    {
        PlayerAttack();
    }

    public void OnUpdate()
    {
        
    }
    public void OnExit()
    {
        _animator.SetBool("Attack", false);        
    }

    public void PlayerAttack()
    {
        _animator.SetBool("Attack", true);
    }

}
