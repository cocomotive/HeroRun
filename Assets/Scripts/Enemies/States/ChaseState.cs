using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{

    FiniteStateMachine<RedEnemyStates> _FSM;
    RedEnemy _redEnemy;
    NavMeshAgent _agent;



    public ChaseState(FiniteStateMachine<RedEnemyStates> FSM, RedEnemy redEnemy, NavMeshAgent agent)
    {
        _FSM = FSM;
        _redEnemy = redEnemy;
        _agent = agent;

    }

    public void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        Chase();
    }
    public void OnExit()
    {
        //_FSM.ChangeState(RedEnemyStates.Patrol);
    }

    public void Chase()
    {
        Debug.Log("entre a Chase");
        float distance = Vector3.Distance(_redEnemy.target.transform.position, _redEnemy.transform.position);

        if (distance <= _redEnemy.lookRadius)
        {
            _agent.SetDestination(_redEnemy.target.transform.position);
        }
        else if(distance > _redEnemy.lookRadius)
        {
            _FSM.ChangeState(RedEnemyStates.Patrol);
        }
    }

}
