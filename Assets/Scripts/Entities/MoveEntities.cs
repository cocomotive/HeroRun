using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEntities : Entities
{
    [Header("Movement")]
    [SerializeField]
    protected CharacterMovement _movements;

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
