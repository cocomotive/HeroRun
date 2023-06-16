using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackClass
{
    [SerializeField]
    Transform reference;

    [SerializeField]
    float _attackDmg;

    public virtual void Attack(params Entities[] toAttack)
    {
        //_sword.enabled = true;

        foreach (var item in toAttack)
        {
            //aca logica de REALIZAR daño
            item.TakeDamage(_attackDmg, reference.position - item.transform.position);//realizo el daño para cada tipo de entidad dentro de mi area de ataque
        }
    }
}
