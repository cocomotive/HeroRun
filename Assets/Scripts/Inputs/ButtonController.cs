using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Controller
{
    GroundChecker _groundChecker;
    Rigidbody _rb;
    Vector3 dir;
    [SerializeField] float _jumpForce;
    [SerializeField] float jumpCount;
    Movements _movements;

   

    public ButtonController(GroundChecker groundChecker, Rigidbody rb, Movements movements)
    {
        _groundChecker = groundChecker;
        _rb = rb;
        _movements = movements;
    }

    public void jump()
    {

        if (_groundChecker.isGrounded)
        {
            _movements.Jump();
        }

    }

    public override Vector3 MoveDir()
    {
        return dir;
    }
}
