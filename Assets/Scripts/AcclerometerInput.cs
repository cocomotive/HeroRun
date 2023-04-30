using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcclerometerInput : MonoBehaviour
{

    [SerializeField] Rigidbody _rb = null;
    [SerializeField] float _speed = 5;


    private void Update()
    {
        var acceleration = Quaternion.Euler(90,0,0) * Input.acceleration;

        Debug.Log(acceleration);

        _rb.AddForce(acceleration * _speed);
    }
}
