using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackClass
{
    [SerializeField]
    float _attackDmg;

    public AttackClass SetDMGMultiply(float m)
    {
        _attackDmg *= m;

        return this;
    }

    public virtual void Attack(Vector3 pos, params Entities[] toAttack)
    {
        //_sword.enabled = true;

        foreach (var item in toAttack)
        {
            //aca logica de REALIZAR da�o
            item.TakeDamage(_attackDmg, pos - item.transform.position);//realizo el da�o para cada tipo de entidad dentro de mi area de ataque
        }
    }
}
