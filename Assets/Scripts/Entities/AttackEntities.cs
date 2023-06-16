using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEntities : MoveEntities
{
    [Header("Attack")]
    public float _radius;

    public Vector3 _distance;

    public LayerMask layerMaskAttack;

    [SerializeField]
    bool damagaToMe = false;

    [SerializeField]
    AttackClass attackClass;

    public virtual void Attack()
    {
        attackClass.Attack(AttackDetection());
    }


    public Vector3 AttackDetectPos()
    {
        return transform.position + (transform.TransformVector(_distance));
    }

    public virtual Entities[] AttackDetection()
    {
        var colAuxs = Physics.OverlapSphere(AttackDetectPos(), _radius, layerMaskAttack);

        List<Entities> result = new List<Entities>();

        foreach (var item in colAuxs)
        {
            if (item.TryGetComponent(out Entities entitie) && !result.Contains(entitie) && (damagaToMe || entitie != this))
            {
                result.Add(entitie);
            }
        }

        return result.ToArray();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(AttackDetectPos(), _radius);
    }
}