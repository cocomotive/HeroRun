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
public class Player : AttackEntities
{
    //FiniteStateMachine<PlayerStates> _FSM;
    [SerializeField] AnimatorController _animatorController;
    [Header("Player")]

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

    //public Health health;

    _EventButton movementController;

    _EventButton jumpController;

    _EventButton attackController;

    public GameManager gameManager;

    public Canvas canvas;

    protected override float dmgMultiply => ItemShop.instance.damageMult;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorController = new AnimatorController(_animator);
        //health = GetComponent<Health>();
        _sword.enabled = false;

        _movements.onAir += _movements_onAir;
        _movements.onGround += _movements_onGround;

        _actualVelocity = _speed;

        movementController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.movement);

        jumpController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.jump);

        attackController = EventManager.events.SearchOrCreate<System.Enum, _Event, _EventButton>(ButtonsController.attack);

        health.onLifeChange += Health_onLifeChange;

        movementController.press += Movement_press;

        movementController.press += AnimationInMove;

        movementController.up += AnimationStopMove;

        attackController.action += AttackController_action;

        jumpController.action += SimpleJump;

    }

    private void Health_onLifeChange(IGetPercentage obj)
    {
        EventManager.events.SearchOrCreate(EnumUI.life).Trigger(obj.Percentage());
    }

    private void Update()
    {
        if (health.life.current <= 0)
        {
            //Activa canvas derrota
            Canvas.FindObjectOfType<Menu>().LoseUI();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WinCheck>()?.Win();
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

        _movements.CancelFall();

        _movements.Impulse(Vector3.up * (_jumpForce*1.5f));

        jumpController.action -= SecondJump;
    }
}


public enum EnumUI
{
    life
}