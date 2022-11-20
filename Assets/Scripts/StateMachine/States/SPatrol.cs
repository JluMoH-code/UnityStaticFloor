using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SPatrol : State
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;

    public int DestPoint { get { return destPoint; } }
    public int NumPoints { get { return points.Length; } }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.Find("TT_demo_zombie").gameObject.GetComponent<Animator>();

        agent.autoBraking = false;

        GotoNextPoint();
    }

    public override void Awake()
    {
        transitions = new List<Transition>();

        transitions.Add(new Transition(GetComponent<CEnemyFound>(), GetComponent<SRunToAttack>()));

        transitions.Add(new Transition(GetComponent<CPathEnd>(), GetComponent<SWaiting>()));

        transitions.Add(new Transition(GetComponent<CWeaponDetect>(), GetComponent<SSearch>()));
    }

    public override void OnEnable()
    {
        Debug.Log("~~On~~ Состояние патрулирования включено!");
        stateEnabled = true;
    }

    public override void OnDisable()
    {
        Debug.Log("~~Off~~ Состояние патрулирования выключено!");
        stateEnabled = false;
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    public override void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        animator.Play("Z_walk");
    }
}
