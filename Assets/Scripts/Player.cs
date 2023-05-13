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
    [SerializeField]
    CharacterMovement _movements;
    //FiniteStateMachine<PlayerStates> _FSM;
    [SerializeField] AnimatorController _animatorController;
    public Collider _sword;
    [SerializeField] Animator _animator;
    [SerializeField] Controller _myController = null;

    [SerializeField]
    float _jumpForce;

    [SerializeField]
    float _jumpCount;

    [SerializeField]
    float _speed;

    [SerializeField]
    float _airSpeed;

    float _actualVelocity;

    public event System.Action jump;

    public WinCheck winCheck;


    private void Awake()
    {
        _movements.Init();
    }


    private void Start()
    {
        //_FSM = new FiniteStateMachine<PlayerStates>();
       
        _animator = GetComponent<Animator>();
        _animatorController = new AnimatorController(_animator);
        _sword.enabled = false;


        //_FSM.AddState(PlayerStates.Idle, new Idle());

        /*
        //Entorno Tierra
        _FSM.AddState(PlayerStates.Run, new Run(_FSM, transform, _myController, _animator, this, _speed, _rotationSpeed));

        //Entorno Aire
        _FSM.AddState(PlayerStates.jump, new Jump(_FSM, _groundChecker, _rb, _animator, this, _jumpForce));
        */

        /*
        _FSM.AddState(PlayerStates.Attack, new Attack(_FSM, _animator, this));
        _FSM.AddState(PlayerStates.Damaged, new Damaged());
        _FSM.AddState(PlayerStates.Dead, new Dead());

        _FSM.ChangeState(PlayerStates.Run);
        */

        _movements.onAir += _movements_onAir;
        _movements.onGround += _movements_onGround;

        _actualVelocity = _speed;
    }

    private void _movements_onGround()
    {
        _actualVelocity = _speed;
    }

    private void _movements_onAir()
    {
        _actualVelocity = _airSpeed;
    }

    void Update()
    {
        //_FSM.Update();
        _movements.Update();
        _movements.movement.Move(_myController.MoveDir(), _actualVelocity);
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
        //_FSM.ChangeState(PlayerStates.Attack);

        _sword.enabled = true;
    }

    public void EndAttack()
    {
        //_FSM.ChangeState(PlayerStates.Run);
    }

    public void FirstJump()
    {
        //_FSM.ChangeState(PlayerStates.jump);
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
        //_rb.AddForce(Vector3.up * (_jumpForce * 1.4f), ForceMode.Impulse);
        //_jumpCount = 0;
        Debug.Log("doble salto");
        _jumpCount++;

    }


}
