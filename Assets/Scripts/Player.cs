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
    [SerializeField] Collider _sword;
    [SerializeField] Animator _animator;
    [SerializeField] Controller _myController = null;
    Rigidbody _rb;
    [SerializeField] float _speed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _jumpCount;
    GroundChecker _groundChecker;
    ButtonController _buttonController;



    private void Start()
    {
        _FSM = new FiniteStateMachine<PlayerStates>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _animator = GetComponent<Animator>();
        _animatorController = new AnimatorController(_animator);
        _sword.enabled = false;
        _rb = GetComponent<Rigidbody>();
        _movements = new Movements(_myController, transform, _rb, _speed, _jumpForce, _rotationSpeed, _animatorController, _jumpCount, _groundChecker);
        _buttonController = new ButtonController(_rb, _movements);
        _FSM.AddState(PlayerStates.Idle, new Idle());
        _FSM.AddState(PlayerStates.Run, new Run(_FSM, transform, _myController, _animator, _speed, _rotationSpeed));
        _FSM.AddState(PlayerStates.jump, new Jump(_FSM, _groundChecker, _rb, _animator, _jumpForce));
        _FSM.AddState(PlayerStates.Attack, new Attack(_FSM, _animator));
        _FSM.AddState(PlayerStates.Damaged, new Damaged());
        _FSM.AddState(PlayerStates.Dead, new Dead());

        _FSM.ChangeState(PlayerStates.Run);

    }

    void Update()
    {
        _FSM.Update();
    }

    private void FixedUpdate()
    {

        //_movements.Move();
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void Jump()
    {
        _FSM.ChangeState(PlayerStates.jump);
    }

    public void Attack()
    {
        _FSM.ChangeState(PlayerStates.Attack);

        _sword.enabled = true;
        
    }

    
}
