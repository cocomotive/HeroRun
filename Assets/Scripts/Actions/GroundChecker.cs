using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    //Bratschi Santiago
    public LayerMask Floor;
    public float radius = 0.3f;
    public bool isGrounded;
    


    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, Floor);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

