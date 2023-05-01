using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IState
{

    FiniteStateMachine<PlayerStates> _FSM;
    GroundChecker _groundChecker;
    Rigidbody _rb;
    Animator _animator;
    float _jumpForce;
    int _jumpCount;


    public Jump(FiniteStateMachine<PlayerStates> FSM, GroundChecker groundChecker, Rigidbody rb, Animator animator, float jumpForce)
    {
        _FSM = FSM;
        _groundChecker = groundChecker;
        _rb = rb;
        _animator = animator;
        _jumpForce = jumpForce;
    }

    public void OnStart()
    {
        PlayerJump();
    }

    public void OnUpdate()
    {
        if (_groundChecker.isGrounded) _FSM.ChangeState(PlayerStates.Run);

    }
    public void OnExit()
    {
        _animator.SetBool("DoubleJump", false);
    }

    public void PlayerJump()
    {

        if (_groundChecker.isGrounded)
        {
            Debug.Log("puedo saltar, estoy grounded");
            _jumpCount = 0;
            _animator.SetBool("Jump", true);

            if (_jumpCount < 1)
            {
                Debug.Log("cambie animacion de salto basico");
                _animator.SetBool("Jump", true);
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _jumpCount++;
                Debug.Log("salte 1 vez");
            }


        }

        else if (_jumpCount == 1 && !_groundChecker.isGrounded)
        {
            _animator.SetBool("DoubleJump", true);
            _animator.SetBool("Jump", false);
            _rb.AddForce(Vector3.up * (_jumpForce * 1.4f), ForceMode.Impulse);
            _jumpCount = 0;
            Debug.Log("doble salto");
        }

    }

}
