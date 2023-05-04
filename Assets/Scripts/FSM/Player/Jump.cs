using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IState
{

    FiniteStateMachine<PlayerStates> _FSM;
    GroundChecker _groundChecker;
    Rigidbody _rb;
    Animator _animator;
    Player _player;
    Timer _timer;
    float _jumpForce;
    


    public Jump(FiniteStateMachine<PlayerStates> FSM, GroundChecker groundChecker, Rigidbody rb, Animator animator, Player player, float jumpForce)
    {
        _FSM = FSM;
        _groundChecker = groundChecker;
        _rb = rb;
        _animator = animator;
        _player = player;
        _jumpForce = jumpForce;

        _timer = TimersManager.Create(0.3f);
    }

    public void OnStart()
    {
        Debug.Log("puedo saltar, estoy grounded");
        Debug.Log("cambie animacion de salto basico");
        _animator.SetTrigger("Jump 0");
        //_animator.SetBool("Jump", true);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        
        Debug.Log("salte 1 vez");

        _player.jump += _player.SecondJump;
        _timer.Reset();
    }


    public void OnUpdate()
    {
        if (!_timer.Chck)
        {
            return;
        }
        if (_groundChecker.isGrounded) _FSM.ChangeState(PlayerStates.Run);

    }
    public void OnExit()
    {
        //_animator.SetBool("DoubleJump", false);
        _player.jump -= _player.SecondJump;              

    }

    public void PlayerJump()
    {

        //if (_jumpCount == 0)
        //{
        //    Debug.Log("puedo saltar, estoy grounded");
        //    Debug.Log("cambie animacion de salto basico");
        //    _animator.SetTrigger("Jump 0");
        //    //_animator.SetBool("Jump", true);
        //    _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //    _jumpCount++;
        //    Debug.Log("salte 1 vez");
        //}

        //else if (_jumpCount == 1)
        //{
        //    //_animator.SetBool("DoubleJump", true);
        //    //_animator.SetBool("Jump", false);
        //    _animator.SetTrigger("DoubleJump 0");
        //    _rb.AddForce(Vector3.up * (_jumpForce * 1.4f), ForceMode.Impulse);
        //    //_jumpCount = 0;
        //    Debug.Log("doble salto");
        //}

    }
    

}
