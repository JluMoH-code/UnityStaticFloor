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
        // инициализация состояния
    }

    public override void OnDisable()
    {
        // завершение состояния
    }

    public override void Update()
    {
        // определяет модель поведения
    }
}
