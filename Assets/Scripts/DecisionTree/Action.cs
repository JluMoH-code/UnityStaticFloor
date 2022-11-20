using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : DecisionTreeNode
{
    public bool activated = false;

    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public void LateUpdate()
    {
        if (!activated)
        {
            return;
            // модели поведения
        }
    }
}
