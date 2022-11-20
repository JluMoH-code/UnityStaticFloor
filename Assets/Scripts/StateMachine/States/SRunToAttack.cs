using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SRunToAttack : State
{
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;

    public override void Awake()
    {
        transitions = new List<Transition>();

        transitions.Add(new Transition(GetComponent<CEnemyLost>(), GetComponent<SPatrol>()));

        transitions.Add(new Transition(GetComponent<CRunToAttack>(), GetComponent<SAttack>()));

        //transitions.Add(new Transition(GetComponent<CEnemyStrong>(), GetComponent<SRunAway>()));
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.Find("TT_demo_zombie").gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        agent.speed *= 1.5f;
    }

    public override void OnEnable()
    {
        Debug.Log("~~On~~Состояние преследоавния включено!");
        stateEnabled = true;    
    }

    public override void OnDisable()
    {
        Debug.Log("~~Off~~Состояние преследоавния выключено!");
        stateEnabled = false;
    }

    public override void Update()
    {
        agent.destination = player.transform.position;              // перемещаем противника в сторону игрока
        animator.Play("Z_run");                                     // проигрываем анимацию бега
    }
}
