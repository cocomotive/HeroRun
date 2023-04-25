using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    Movements _movements;
    [SerializeField] AnimatorController _animatorController;
    [SerializeField] Collider _sword;
    [SerializeField] Animator _animator;
    [SerializeField] Controller _myController = null;
    Rigidbody _rb;
    [SerializeField] float speed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _jumpCount;
    GroundChecker _groundChecker;
    ButtonController _buttonController;



    private void Start()
    {
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _animator = GetComponent<Animator>();
        _animatorController = new AnimatorController(_animator);
        _sword.enabled = false;
        _rb = GetComponent<Rigidbody>();
        _movements = new Movements(_myController, transform, _rb, speed, _jumpForce, _rotationSpeed, _animatorController, _jumpCount, _groundChecker);
        _buttonController = new ButtonController(_rb, _movements);

    }

    void Update()
    {
    }

    private void FixedUpdate()
    {

        _movements.Move();
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void Jump()
    {
        Debug.Log(_movements);
        _movements.Jump();
    }

    public void Attack()
    {
        _sword.enabled = true;
        _animatorController.PlayAttack(true);
        _animatorController.PlayIdle(false);
        _animatorController.PlayRun(false);

    }
}
