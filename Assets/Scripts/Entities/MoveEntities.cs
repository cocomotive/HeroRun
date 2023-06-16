using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEntities : Entities
{
    [Header("Movement")]
    [SerializeField]
    protected CharacterMovement _movements;

    public override void TakeDamage(float dmg, Vector3 dirDamage)
    {
        dirDamage.y = 0;

        _movements.CancelFall();
        _movements.Impulse(Vector3.up * 3);
        _movements.movement.AddVelocity(dirDamage.normalized * -10);

        base.TakeDamage(dmg, dirDamage); 
    }

    protected override void Awake()
    {
        base.Awake();

        _movements.Init();
    }

    protected virtual void Update()
    {
        _movements.Update();
    }

}
