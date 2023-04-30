using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    FiniteStateMachine<RedEnemyStates> _FSM;
    RedEnemy _redEnemy;
    Animator _animator;
    Transform _transform;
    float _patrolSpeed = 5;



    public PatrolState(FiniteStateMachine<RedEnemyStates> FSM, RedEnemy redEnemy, Animator animator, Transform  transform)
    {
        _FSM = FSM;
        _redEnemy = redEnemy;
        _animator = animator;
        _transform = transform;

    }

    public void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        Patrol();
    }
    public void OnExit()
    {
        Debug.Log("Salí de Patrol");
    }



    private void Patrol() 
    {
        if (_transform.position != _redEnemy._patrolPoints[_redEnemy._currentPatrolPoint].position)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _redEnemy._patrolPoints[_redEnemy._currentPatrolPoint].position, _patrolSpeed * Time.deltaTime);
        }

        else _redEnemy._currentPatrolPoint = (_redEnemy._currentPatrolPoint + 1) % _redEnemy._patrolPoints.Length;


    }
}
