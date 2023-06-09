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
    float _attackDmg;

    public virtual void Attack()
    {
        //_sword.enabled = true;

        foreach (var item in AttackDetection())
        {
            //aca logica de REALIZAR daño
            item.health.TakeDamage(_attackDmg);//realizo el daño para cada tipo de entidad dentro de mi area de ataque
        }
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
