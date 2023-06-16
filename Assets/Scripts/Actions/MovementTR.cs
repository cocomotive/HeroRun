using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTR : Movement
{

    public float desaceleration;

    protected override void InternalMove(Vector3 dir, float velocity)
    {
        transform.position += new Vector3(dir.x, 0, dir.z) * velocity * Time.deltaTime;
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, velocity.magnitude - Time.deltaTime * desaceleration);
    }
}
