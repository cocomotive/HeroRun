using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    /*
    public event System.Action onGround;
    public event System.Action stayGround;
    */

    public Vector3 velocity;

    [SerializeField]
    float _speed;

    [SerializeField]
    float _rotationSpeed;


    //Rigidbody _rb;

    /*
    private void Awake()
    {
        //_rb = GetComponent<Rigidbody>();
        entorno = new FSMEntorno(this);
    }
    */

    public void Move(Vector3 dir)
    {
        Move(dir, _speed);
    }

    public void Move(Vector3 dir, float velocity)
    {
        if (dir != Vector3.zero)
        {
            //transform.position += new Vector3(dir.x, 0, dir.z) * velocity * Time.deltaTime;
            InternalMove(dir, velocity);

            transform.forward += dir * Time.deltaTime * _rotationSpeed;
        }
    }

    public void AddVelocity(Vector3 velocity)
    {
        this.velocity += velocity;
    }

    abstract protected void InternalMove(Vector3 dir, float velocity);
}
