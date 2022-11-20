using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CRunToAttack : Condition
{
    private GameObject player = null;
    private float distanceToPlayer = 0;             // расстояние до игрока
    public float distanceToChangeState;        // дистанция до игрока, при которой происходит смена состояния
    private NavMeshAgent agent = null;
    private NavMeshPath path;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    public override bool Test()
    {
        if (IsEnemyFound())
            return true;
        return false;
    }

    public bool IsEnemyFound()
    {
        distanceToPlayer = 0;
        // Debug.Log(agent.transform.position.ToString());
        if (NavMesh.CalculatePath(agent.transform.position, player.transform.position, 1, path))
        {
            distanceToPlayer += Vector3.Distance(transform.position, path.corners[0]);
            for (int i = 1; i < path.corners.Length; i++)
            {
                distanceToPlayer += Vector3.Distance(path.corners[i - 1], path.corners[i]);
                if (distanceToPlayer >= distanceToChangeState)
                {
                    break;
                }
            }

            if (distanceToPlayer <= distanceToChangeState)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}
