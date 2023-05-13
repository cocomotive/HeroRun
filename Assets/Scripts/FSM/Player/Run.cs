using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : IState
{
    //FiniteStateMachine<PlayerStates> _FSM;
    Transform _transform;
    Controller _myController;
    Animator _animator;
    Player _player;
    float _speed;
    float _rotationSpeed;

    /*
    public Run(FiniteStateMachine<PlayerStates> FSM, Transform transform, Controller controller, Animator animator, Player player, float speed, float rotationSpeed)
    {
        _FSM = FSM;
        _transform = transform;
        _myController = controller;
        _animator = animator;
        _player = player;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }
    */

    public void OnStart()
    {
        Debug.Log("toy en el piso");
        _player.jump += _player.FirstJump;
        //_player._jumpCount = 0;
        _animator.SetTrigger("Grounded");
    }

    public void OnUpdate()
    {
        Move();
        AnimationMove();
    }

    public void OnExit()
    {
        _player.jump -= _player.FirstJump;
        _animator.ResetTrigger("Grounded");
    }

    public void Move()
    {
        Vector3 myDir = _myController.MoveDir();
        if (myDir != Vector3.zero)
        {
            _transform.position += new Vector3(myDir.x, 0, myDir.z) * _speed * Time.deltaTime;
            _transform.forward += myDir * Time.deltaTime * _rotationSpeed;
        }
    }

    public void AnimationMove()
    {
        _animator.SetFloat("Horizontal", _myController.MoveDir().x);
        _animator.SetFloat("Vertical", _myController.MoveDir().z);
    }
}
