using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController 
{
    //GroundChecker _groundChecker;
    Rigidbody _rb;
    Vector3 dir;
    [SerializeField] float _jumpForce;
    [SerializeField] float jumpCount;
    Movements _movements;



    public ButtonController(Rigidbody rb, Movements movements)
    {
        //_groundChecker = groundChecker;
        _rb = rb;
        _movements = movements;
    }

    public void Jump()
    {
        Debug.Log(_movements);
        _movements.Jump();
    }

}
