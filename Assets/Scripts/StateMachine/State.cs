using UnityEngine;

// класс реализует действие объекта при данном состоянии

using System.Collections.Generic;

public class State : MonoBehaviour
{
    public List<Transition> transitions = null;
    public bool stateEnabled = false;

    public virtual void Awake()
    {
        // содержит набор состояний, в которые возможен переход
    }

    public virtual void OnEnable()
    {
        // инициализация состояния
    }

    public virtual void OnDisable()
    {
        // завершение состояния
    }

    public virtual void Update()
    {
        // определяет модель поведения
    }

    public void LateUpdate()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.condition.Test())
            {
                transition.targetState.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }
}
