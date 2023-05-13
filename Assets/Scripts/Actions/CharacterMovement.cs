using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterMovement
{
    public event System.Action onGround
    {
        add
        {
            entorno.onGround += value;
        }
        remove
        {
            entorno.onGround -= value;
        }
    }

    public event System.Action stayGround
    {
        add
        {
            entorno.stayGround += value;
        }
        remove
        {
            entorno.stayGround -= value;
        }
    }

    public event System.Action onAir
    {
        add
        {
            entorno.onAir += value;
        }
        remove
        {
            entorno.onAir -= value;
        }
    }

    public event System.Action stayAir
    {
        add
        {
            entorno.stayAir += value;
        }
        remove
        {
            entorno.stayAir -= value;
        }
    }

    public Movement movement;

    [SerializeField]
    GroundChecker _groundChecker;

    FSMEntorno entorno;

    [SerializeField]
    AnimatorController _animatorController;

    public void Init()
    {
        entorno = new FSMEntorno(movement);

        _groundChecker.onFloor += _groundChecker_onFloor;
        _groundChecker.noFloor += _groundChecker_noFloor;
    }

    public void Update()
    {
        entorno.Update();
    }

    private void _groundChecker_noFloor()
    {
        entorno.ChangeState(entorno.aire);
    }

    private void _groundChecker_onFloor()
    {
        entorno.ChangeState(entorno.tierra);
    }
}



public class FSMEntorno : FSMachine<FSMEntorno, Movement>
{
    public EventState tierra = new EventState();

    public EventState aire = new EventState();

    public event System.Action onGround
    {
        add
        {
            tierra.on += value;
        }
        remove
        {
            tierra.on -= value;
        }
    }

    public event System.Action stayGround
    {
        add
        {
            tierra.stay += value;
        }
        remove
        {
            tierra.stay -= value;
        }
    }

    public event System.Action onAir
    {
        add
        {
            aire.on += value;
        }
        remove
        {
            aire.on -= value;
        }
    }

    public event System.Action stayAir
    {
        add
        {
            aire.stay += value;
        }
        remove
        {
            aire.stay -= value;
        }
    }
    public FSMEntorno(Movement context) : base(context)
    {
        InitState(tierra);
    }
}

public class EventState : IState<FSMEntorno>
{
    public event System.Action on;

    public event System.Action stay;

    public void OnExit(FSMEntorno param)
    {
    }

    public void OnStart(FSMEntorno param)
    {
        on?.Invoke();
    }

    public void OnUpdate(FSMEntorno param)
    {
        stay?.Invoke();
    }
}
