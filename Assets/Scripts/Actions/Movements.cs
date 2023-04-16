using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements
{
    [SerializeField] Controller _myController;
    [SerializeField] AnimatorController _animatorController;
    Transform _transform;
    Rigidbody _rb;
    float _speed;
    float _jumpForce;
    float _rotationSpeed;
    float _jumpCount;
    GroundChecker _groundChecker;

    public Movements(Controller controller, Transform transform, Rigidbody rb, float speed, float jumpForce, float rotationSpeed, AnimatorController animatorController, float jumpCount, GroundChecker groundChecker)
    {
        _myController = controller;
        _animatorController = animatorController;
        _transform = transform;
        _rb = rb;
        _speed = speed;
        _jumpForce = jumpForce;
        _rotationSpeed = rotationSpeed;
        _jumpCount = jumpCount;
        _groundChecker = groundChecker;

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

    public void Jump()
    {

        Debug.Log("puedo saltar, estoy grounded");
        if (_jumpCount < 1)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            //dir.y = jumpForce;
            _jumpCount++;
            Debug.Log("salte 1 vez");
        }

        else if (_jumpCount >= 1)
        {
            //dir.y = jumpForce * 0.5f;
            _jumpCount = 0;
            Debug.Log("doble salto");
        }

    }


    public void Attack()
    {

    }
}
