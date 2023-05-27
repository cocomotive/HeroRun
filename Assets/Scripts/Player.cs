using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum PlayerStates
{
    Idle,
    Run,
    jump,
    Attack,
    Damaged,
    Dead
}
public class Player : Entities
{
    [SerializeField]
    CharacterMovement _movements;
    //FiniteStateMachine<PlayerStates> _FSM;
    [SerializeField] AnimatorController _animatorController;
    public Collider _sword;
    [SerializeField] Animator _animator;
    //[SerializeField] Controller _myController = null;

    [SerializeField]
    float _jumpForce;

    /*
    [SerializeField]
    float _jumpCount;
    */

    [SerializeField]
    float _speed;

    [SerializeField]
    float _airSpeed;

    float _actualVelocity;

    public event System.Action jump;

    public WinCheck winCheck;

    [Header("Attack")]
    public float _radius;

    public Vector3 _distance;

    public LayerMask layerMaskAttack;


    _EventButton movementController;

    _EventButton jumpController;

    _EventButton attackController;


    override protected void Awake()
    {
        base.Awake();
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

        movementController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.movement);

        jumpController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.jump);

        attackController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.attack);

        movementController.press += Movement_press;

        movementController.press += AnimationInMove;

        movementController.up += AnimationStopMove;

        attackController.action += AttackController_action;

        jumpController.action += SimpleJump;
    }

    private void SimpleJump(params object[] parameters)
    {
        _animator.SetTrigger("Jump 0");
        _animator.ResetTrigger("Grounded");

        _movements.Impulse(Vector3.up * _jumpForce);

        //_rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); movimiento se tendria que encargar del impulso
    }

    private void AnimationStopMove(Vector3 obj)
    {
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 0);
    }

    private void AnimationInMove(Vector3 obj)
    {
        _animator.SetFloat("Horizontal", obj.x);
        _animator.SetFloat("Vertical", obj.z);
    }

    private void AttackController_action(params object[] parameters)
    {
        _animator.SetTrigger("Attack");
    }

    private void Movement_press(Vector3 obj)
    {
        _movements.movement.Move(obj, _actualVelocity);
    }

    private void _movements_onGround()
    {
        _actualVelocity = _speed;

        _animator.SetTrigger("Grounded");

        movementController.press += AnimationInMove;

        jumpController.action -= SecondJump;

        jumpController.action += SimpleJump;
    }

    private void _movements_onAir()
    {
        _actualVelocity = _airSpeed;

        movementController.press -= AnimationInMove;

        jumpController.action -= SimpleJump;

        jumpController.action += SecondJump;
    }

    private void SecondJump(params object[] parameters)
    {
        SecondJump();
    }

    void Update()
    {
        _movements.Update();
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WinCheck>()?.Win();
    }

    public void Attack()
    {
        //_sword.enabled = true;

        foreach (var item in AttackDetection())
        {
            //aca logica de REALIZAR daño
        }
    }

    /*
    public void EndAttack()
    {
        _sword.enabled = false;
    }
    */

    public void FirstJump()
    {
        //_FSM.ChangeState(PlayerStates.jump);
    }

    public void SecondJump()
    {
        //_animator.SetBool("DoubleJump", true);
        //_animator.SetBool("Jump", false);
        _animator.SetTrigger("DoubleJump 0");
        //_rb.AddForce(Vector3.up * (_jumpForce * 1.4f), ForceMode.Impulse);
        //_jumpCount = 0;
        Debug.Log("doble salto");

        _movements.Impulse(Vector3.up * (_jumpForce*1.5f));

        jumpController.action -= SecondJump;
    }

    public Vector3 AttackDetectPos()
    {
        return transform.position + (transform.TransformVector(_distance));
    }

    public virtual Collider[] AttackDetection()
    {
        return Physics.OverlapSphere(AttackDetectPos(), _radius, layerMaskAttack);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(AttackDetectPos(), _radius);
    }

}
