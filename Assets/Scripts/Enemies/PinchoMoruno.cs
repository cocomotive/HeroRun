using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchoMoruno : MonoBehaviour
{
    [SerializeField]
    AttackClass attackClass;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Entities>(out var entity))
        {
            attackClass.Attack(collision.GetContact(0).point , entity);
        }
    }
}
