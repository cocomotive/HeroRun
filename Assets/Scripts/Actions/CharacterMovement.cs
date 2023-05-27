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
            _entorno.onGround += value;
        }
        remove
        {
            _entorno.onGround -= value;
        }
    }

    public event System.Action stayGround
    {
        add
        {
            _entorno.stayGround += value;
        }
        remove
        {
            _entorno.stayGround -= value;
        }
    }

    public event System.Action onAir
    {
        add
        {
            _entorno.onAir += value;
        }
        remove
        {
            _entorno.onAir -= value;
        }
    }

    public event System.Action stayAir
    {
        add
        {
            _entorno.stayAir += value;
        }
        remove
        {
            _entorno.stayAir -= value;
        }
    }

    public Movement movement;

    [SerializeField]
    GroundChecker _groundChecker;

    FSMEntorno _entorno;

    [SerializeField]
    AnimatorController _animatorController;

    Rigidbody _rb;

    public void Init()
    {
        _entorno = new FSMEntorno(movement);

        _rb = movement.GetComponent<Rigidbody>();

        _groundChecker.onFloor += _groundChecker_onFloor;
        _groundChecker.noFloor += _groundChecker_noFloor;
    }

    public void Update()
    {
        _entorno.Update();
    }

    private void _groundChecker_noFloor()
    {
        _entorno.ChangeState(_entorno.aire);
    }

    private void _groundChecker_onFloor()
    {
        _entorno.ChangeState(_entorno.tierra);
    }

    public void Impulse(Vector3 dir)
    {
        //_rb.AddForce(dir, ForceMode.Impulse);

        _rb.velocity = dir;
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
