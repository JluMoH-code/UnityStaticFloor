using UnityEngine;
using UnityEngine.AI;

// описывает изменения состояний при условии, что обнаружен противник

public class CEnemyFound : Condition
{
    private GameObject player = null;               // игрок
    private float distanceToPlayer = 0;             // расстояние до игрока
    private float distanceToChangeState = 10;       // дистанция до игрока, при которой происходит смена состояния
    private NavMeshAgent agent = null;              // ИИ агента (для вычисления расстояния)
    private NavMeshPath path;                       // набор вершин, из которых состоит путь (для вычисления расстояния)

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

        // Вычисляем длину траектории до игрока

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

            // Если длина траектории < дистанция обнаружения, то меняем состояние

            if (distanceToPlayer <= distanceToChangeState)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}
