using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SAttack : State
{
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.Find("TT_demo_zombie").gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Awake()
    {
        transitions = new List<Transition>();

        transitions.Add(new Transition(GetComponent<CEnemyDied>(), GetComponent<SPatrol>()));

        //transitions.Add(new Transition(GetComponent<CEnemyFound>(), GetComponent<SRunToAttack>()));

        transitions.Add(new Transition(GetComponent<CEnemyLost>(), GetComponent<SSearch>()));
    }

    public override void OnEnable()
    {
        Debug.Log("~~On~~ Состояние атаки включено!");
        stateEnabled = true;
    }

    public override void OnDisable()
    {
        Debug.Log("~~Off~~ Состояние атаки выключено!");
        stateEnabled = false;
    }

    public override void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= 1)
        {
            agent.destination = player.transform.position;
            animator.Play("Z_run");
        }
        else
        {
            animator.Play("Z_attack");

            // player.GetComponent<Player>().Health -= 10;

            // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime / animator.GetCurrentAnimatorStateInfo(0).length);

            // events...
        }
    }
}
