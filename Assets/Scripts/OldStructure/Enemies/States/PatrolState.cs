using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private int _currentWP = 0;
    private FiniteStateMachine<RedEnemy> _fsm;
    private RedEnemy _redEnemy;
    private float _speed;
    private float _viewRange;
    public Transform[] movePoints;
    private Transform _myPos;
    private int _currentPos = 0;
    private int _changeTargetDist = 0;


    public PatrolState(FiniteStateMachine<RedEnemy> fsm, RedEnemy redEnemy, float speed, float viewRange, Transform[] waypoints, Transform myPos, int currentPos, int changeTargetDist)
    {
        _fsm = fsm;
        _redEnemy = redEnemy;
        _speed = speed;
        _viewRange = viewRange;
        movePoints = waypoints;
        _myPos = myPos;
        _currentPos = currentPos;
        _changeTargetDist = changeTargetDist;
    }

    public void OnStart()
    {
        Debug.Log("estoy patrullando");
        _redEnemy._target = null;
    }

    public void OnUpdate()
    {
        Patrol();
    }
    public void OnExit()
    {
        Debug.Log("Salí de Patrol");
    }



    private bool Patrol()
    {
        Vector3 distanceVector = movePoints[_currentPos].position - _myPos.transform.position;
        if (distanceVector.magnitude < _changeTargetDist)
        {
            return true;
        }
        Vector3 velocityVector = distanceVector.normalized;
        _myPos.transform.position += velocityVector * _speed * Time.deltaTime;
        return false;

    }
}
