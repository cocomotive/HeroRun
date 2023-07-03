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
            //aca logica de REALIZAR daño
            item.TakeDamage(_attackDmg, pos - item.transform.position);//realizo el daño para cada tipo de entidad dentro de mi area de ataque
        }
    }
}
