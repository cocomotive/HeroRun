using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RedEnemy : AttackEntities
{
    //[SerializeField] float _enemySpeed;
    //[SerializeField] float _enemyViewRange;
    //[SerializeField] float _enemyMaxLife;
    //[SerializeField] float _enemyCurrentLife;

    [SerializeField] Animator _animator;

    //private FiniteStateMachine<RedEnemyStates> _FSM;
    public Player target;
    public float lookRadius;

    public Patrol patrol;

    public float deleyAttaque = 1;

    FSMEnemy fsmEnemy;

    Timer attackDeley;

    Vector3 distance;

    public override void Attack()
    {
        if (attackDeley.Chck)
        {
            attackDeley.Reset();
            base.Attack();
        }
    }

    protected override void Awake()
    {
        base.Awake();

        attackDeley = TimersManager.Create(deleyAttaque);        

        patrol.Init(transform);

        fsmEnemy = new FSMEnemy(this);

        _movements.onGround += _movements_onGround;

        _movements.onAir += _movements_onAir;

        fsmEnemy.stayPersuit += FsmEnemy_stayPersuit;

        fsmEnemy.stayPatrol += FsmEnemy_stayPatrol;

        health.onDeath += Health_onDeath;
    }

    private void Health_onDeath()
    {
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();

        fsmEnemy.Update();

        distance = target.transform.position - transform.position;

        if (distance.sqrMagnitude < lookRadius * lookRadius)
        {
            fsmEnemy.ChangeState(fsmEnemy.persuit);
        }
        else
        {
            fsmEnemy.ChangeState(fsmEnemy.patrol);
        }
    }

    private void FsmEnemy_stayPatrol()
    {
        if(!patrol.MinimalChck())
        {
            _movements.movement.Move(Vector3.ClampMagnitude(patrol.Distance(), 1));
        }
        else if(patrol.patrolCount > 1)
        {
            patrol.NextPoint();
        }
    }

    private void FsmEnemy_stayPersuit()
    {
        if (distance.sqrMagnitude < _radius * _radius)
        {
            Attack();
        }
        else
        {
            _movements.movement.Move(distance.normalized);
        }  
    }

    private void _movements_onAir()
    {
        fsmEnemy.stayPersuit -= FsmEnemy_stayPersuit;

        fsmEnemy.stayPatrol -= FsmEnemy_stayPatrol;
    }

    private void _movements_onGround()
    {
        fsmEnemy.stayPersuit += FsmEnemy_stayPersuit;

        fsmEnemy.stayPatrol += FsmEnemy_stayPatrol;
    }

    
}


public class FSMEnemy : FSMachine<FSMEnemy, RedEnemy>
{
    public EventState<FSMEnemy> patrol = new EventState<FSMEnemy>();

    public EventState<FSMEnemy> persuit = new EventState<FSMEnemy>();

    public event System.Action onPatrol
    {
        add
        {
            patrol.on += value;
        }
        remove
        {
            patrol.on -= value;
        }
    }

    public event System.Action stayPatrol
    {
        add
        {
            patrol.stay += value;
        }
        remove
        {
            patrol.stay -= value;
        }
    }

    public event System.Action onPersuit
    {
        add
        {
            persuit.on += value;
        }
        remove
        {
            persuit.on -= value;
        }
    }

    public event System.Action stayPersuit
    {
        add
        {
            persuit.stay += value;
        }
        remove
        {
            persuit.stay -= value;
        }
    }

    public FSMEnemy(RedEnemy context) : base(context)
    {
        InitState(patrol);
    }
}


[System.Serializable]
public class Patrol
{
    public Transform context;

    public Transform patrolParent;
    public int indexPatrolPoint;

    public float minimalDistance;

    Vector3 distance;

    public Transform actualPoint
    {
        get => patrolParent.GetChild(indexPatrolPoint);
    }

    public int patrolCount => patrolParent.childCount;

    public void NextPoint()
    {
        indexPatrolPoint++;

        if(indexPatrolPoint >= patrolCount)
        {
            indexPatrolPoint = 0;
        }
    }

    public Vector3 Distance()
    {
        distance = Distance(indexPatrolPoint);

        return distance;
    }

    public Vector3 Distance(int index)
    {
        var aux = patrolParent.GetChild(index).position - context.position;

        aux.y = 0;

        return aux;
    }

    public bool MinimalChck()
    {
        return distance.sqrMagnitude < minimalDistance * minimalDistance;
    }

    public void Init(Transform context)
    {
        this.context = context;

        if(patrolParent == null)
        {
            patrolParent = new GameObject(context.name + " PatrollParent").transform;
        }

        if(patrolCount == 0)
        {
            var aux = new GameObject(context.name + " Patroll Default").transform;

            aux.position = context.position;

            aux.SetParent(patrolParent);
        }
    }
}