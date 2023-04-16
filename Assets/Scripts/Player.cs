using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    Movements _movements;
    [SerializeField] AnimatorController _animatorController;

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
        _rb = GetComponent<Rigidbody>();
        _movements = new Movements(_myController, transform, _rb, speed, _jumpForce, _rotationSpeed, _animatorController, _jumpCount, _groundChecker);
        _buttonController = new ButtonController(_groundChecker, _rb, _movements);
    }

    void Update()
    {              
    }

    private void FixedUpdate()
    {
        _movements.Move();

        //if (_groundChecker.isGrounded)
        //{
        //    _buttonController.jump();
        //}
        
    }



}
