using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public Player target;
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public float lookRadius;
    NavMeshAgent agent;

    
    void Start()
    {
        currentPatrolPoint = 0;
        _FSM = new FiniteStateMachine<RedEnemyStates>();
        //agent = GetComponent<NavMeshAgent>();

        _FSM.AddState(RedEnemyStates.Patrol, new PatrolState(_FSM, this, _animator, transform));
        _FSM.AddState(RedEnemyStates.Chase, new ChaseState(_FSM, this, agent));
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
