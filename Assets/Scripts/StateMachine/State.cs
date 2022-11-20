using UnityEngine;

// ����� ��������� �������� ������� ��� ������ ���������

using System.Collections.Generic;

public class State : MonoBehaviour
{
    public List<Transition> transitions = null;
    public bool stateEnabled = false;

    public virtual void Awake()
    {
        // �������� ����� ���������, � ������� �������� �������
    }

    public virtual void OnEnable()
    {
        // ������������� ���������
    }

    public virtual void OnDisable()
    {
        // ���������� ���������
    }

    public virtual void Update()
    {
        // ���������� ������ ���������
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
