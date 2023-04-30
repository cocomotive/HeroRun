using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{

    FiniteStateMachine<RedEnemyStates> _FSM;



    public ChaseState(FiniteStateMachine<RedEnemyStates> FSM)
    {
        _FSM = FSM;

    }

    public void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        
    }
    public void OnExit()
    {
        
    }

}
