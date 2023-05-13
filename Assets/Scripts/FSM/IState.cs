using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnStart();
    public void OnUpdate();
    public void OnExit();
}


public interface IState<FSM>
{
    public void OnStart(FSM param);
    public void OnUpdate(FSM param);
    public void OnExit(FSM param);
}