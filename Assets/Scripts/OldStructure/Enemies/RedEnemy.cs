using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RedEnemyStates
{
    Patrol,
    Attack,
    Hurt,
    Dead
}


public class RedEnemy : MonoBehaviour
{

    [SerializeField] float _enemySpeed;
    [SerializeField] float _enemyViewRange;
    [SerializeField] float _enemyMaxLife;
    [SerializeField] float _enemyCurrentLife;

    private FiniteStateMachine _FSM;
    public Player _target;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //cambiar estado a Hurt
        }
        
    }
}
