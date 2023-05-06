using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    FiniteStateMachine<PlayerStates> _FSM;
    //Transform _transform;
    //Controller _myController;
    Animator _animator;
    Player _player;
    Timer timerEnd;
    //float _speed;
    //float _rotationSpeed;

    public Attack(FiniteStateMachine<PlayerStates> FSM, Animator animator, Player player)
    {
        _FSM = FSM;
        _animator = animator;
        _player = player;

        timerEnd = TimersManager.Create(0.5f, ()=> { FSM.ChangeState(PlayerStates.Run); });
    }

    public void OnStart()
    {
        _animator.SetBool("Attack", true);
        _player._sword.enabled = true;
        timerEnd.Reset();
    }

    public void OnUpdate()
    {

    }
    public void OnExit()
    {
        _animator.SetBool("Attack", false);
        _player._sword.enabled = false;
    }

    public void PlayerAttack()
    {

    }

}
