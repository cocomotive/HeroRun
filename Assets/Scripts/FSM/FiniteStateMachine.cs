using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine<T>
{
    private IState _currentState;
    private Dictionary<T, IState> _allStates = new Dictionary<T, IState>();

    public void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(T state)
    {
        if (!_allStates.ContainsKey(state) || _currentState == _allStates[state]) return;
        if (_currentState != null) _currentState.OnExit();
        _currentState = _allStates[state];
        _currentState.OnStart();
    }

    public void AddState(T key, IState value)
    {
        if (!_allStates.ContainsKey(key)) _allStates.Add(key, value);
        else _allStates[key] = value;
    }

}
