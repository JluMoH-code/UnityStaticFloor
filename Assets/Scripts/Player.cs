using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Camera mainCam;
    public float moveSpeed;

    private float health = 100;
    public float Health { get { return health; } set { health = value; } }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float x = 0, z = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            z = Input.GetAxis("Vertical");

        Vector3 move = (mainCam.transform.right * x + mainCam.transform.forward * z);

        // normalize move if has a magnitude > 1 to prevent faster diagonal movement
        if (move.sqrMagnitude > 1)
        {
            move.Normalize();
        }

        //transform.position = transform.position + move * moveSpeed * Time.deltaTime;

        navMeshAgent.velocity = move * moveSpeed;

        // Debug.Log(health);
    }
}
