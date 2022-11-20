using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWaiting : State
{
    public override void Awake()
    {
        transitions = new List<Transition>();

        transitions.Add(new Transition(GetComponent<CTimeOut>(), GetComponent<SPatrol>()));

        transitions.Add(new Transition(GetComponent<CEnemyFound>(), GetComponent<SAttack>()));
    }

    public override void OnEnable()
    {
        // ������������� ���������
    }

    public override void OnDisable()
    {
        // ���������� ���������
    }

    public override void Update()
    {
        // ���������� ������ ���������
    }
}
