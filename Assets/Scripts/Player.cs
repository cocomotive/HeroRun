using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public enum PlayerStates
{
    Idle,
    Run,
    jump,
    Attack,
    Damaged,
    Dead
}
public class Player : MonoBehaviour
{

    Movements _movements;
    FiniteStateMachine<PlayerStates> _FSM;
    [SerializeField] AnimatorController _animatorController;
    public Collider _sword;
    [SerializeField] Animator _animator;
    [SerializeField] Controller _myController = null;
    Rigidbody _rb;
    [SerializeField] float _speed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] float _rotationSpeed;
    public float _jumpCount;
    GroundChecker _groundChecker;

    public event System.Action jump;

    public WinCheck winCheck;



    private void Start()
    {
        _FSM = new FiniteStateMachine<PlayerStates>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _animator = GetComponent<Animator>();
        _animatorController = new AnimatorController(_animator);
        _sword.enabled = false;
        _rb = GetComponent<Rigidbody>();
        _movements = new Movements(_myController, transform, _rb, _speed, _jumpForce, _rotationSpeed, _animatorController, _jumpCount, _groundChecker);
        
        //_FSM.AddState(PlayerStates.Idle, new Idle());

        //Entorno Tierra
        _FSM.AddState(PlayerStates.Run, new Run(_FSM, transform, _myController, _animator, this, _speed, _rotationSpeed));

        //Entorno Aire
        _FSM.AddState(PlayerStates.jump, new Jump(_FSM, _groundChecker, _rb, _animator, this, _jumpForce));



        _FSM.AddState(PlayerStates.Attack, new Attack(_FSM, _animator, this));
        _FSM.AddState(PlayerStates.Damaged, new Damaged());
        _FSM.AddState(PlayerStates.Dead, new Dead());

        _FSM.ChangeState(PlayerStates.Run);

    }

    void Update()
    {
        _FSM.Update();
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WinCheck>()?.Win();
    }

    public void Jump()
    {
        //_FSM.ChangeState(PlayerStates.jump);
        jump?.Invoke();
    }


    public void Attack()
    {
        _FSM.ChangeState(PlayerStates.Attack);

        _sword.enabled = true;
    }

    public void EndAttack()
    {
        _FSM.ChangeState(PlayerStates.Run);
    }

    public void FirstJump()
    {
        _FSM.ChangeState(PlayerStates.jump);
    }

    public void SecondJump()
    {
        if (_jumpCount >= 1)
        {
            return;
        }

        //_animator.SetBool("DoubleJump", true);
        //_animator.SetBool("Jump", false);
        _animator.SetTrigger("DoubleJump 0");
        _rb.AddForce(Vector3.up * (_jumpForce * 1.4f), ForceMode.Impulse);
        //_jumpCount = 0;
        Debug.Log("doble salto");
        _jumpCount++;

    }


}
