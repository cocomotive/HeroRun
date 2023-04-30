using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _smoothing = 5;
    Vector3 Offset;


    private void Start()
    {
        Offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetLocation = _target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, targetLocation, _smoothing * Time.deltaTime);
    }
}
