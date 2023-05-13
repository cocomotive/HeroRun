using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class FSMachine<T, C> : FSMachineSerialize<T, C> where T : FSMachine<T, C>
{
    public FSMachine(C context)
    {
        Init(context);
    }
}

[System.Serializable]
public abstract class FSMachineSerialize<T,C> where T : FSMachineSerialize<T,C> 
{
    /*
    YO a la hora de heredar esta clase le aclaro en el tipo T quien va a ser el hijo que hereda
    */

    public C context;

    private IState<T> _currentState;

    T Child
    {
        get => (T)this;
    }

    public void Update()
    {
        _currentState.OnUpdate(Child);
    }

    public void ChangeState(IState<T> state)
    {
        if (state == null || state == _currentState)
            return;

        _currentState.OnExit(Child);

        InitState(state);
    }

    protected void InitState(IState<T> state)
    {
        _currentState = state;

        _currentState.OnStart(Child);
    }

    public void Init(C context)
    {
        this.context = context;
    }
}