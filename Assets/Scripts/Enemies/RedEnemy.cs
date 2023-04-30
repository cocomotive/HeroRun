using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RedEnemyStates
{
    Patrol,
    Chase,
    Attack,
    Hurt,
    Dead
}


public class RedEnemy : MonoBehaviour
{
    //[SerializeField] float _enemySpeed;
    //[SerializeField] float _enemyViewRange;
    //[SerializeField] float _enemyMaxLife;
    //[SerializeField] float _enemyCurrentLife;

    [SerializeField] Animator _animator;

    private FiniteStateMachine<RedEnemyStates> _FSM;
    public Player _target;
    public Transform[] _patrolPoints;
    public int _currentPatrolPoint;

    
    void Start()
    {
        _currentPatrolPoint = 0;
        _FSM = new FiniteStateMachine<RedEnemyStates>();

        _FSM.AddState(RedEnemyStates.Patrol, new PatrolState(_FSM, this, _animator, transform));
        _FSM.AddState(RedEnemyStates.Chase, new ChaseState(_FSM));
        _FSM.AddState(RedEnemyStates.Attack, new AttackState());
        _FSM.AddState(RedEnemyStates.Hurt, new HurtState());
        _FSM.AddState(RedEnemyStates.Dead, new DeadState());

        _FSM.ChangeState(RedEnemyStates.Patrol);

    }

  
    void Update()
    {
        _FSM.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //cambiar estado a Hurt
        }
        
    }
}
