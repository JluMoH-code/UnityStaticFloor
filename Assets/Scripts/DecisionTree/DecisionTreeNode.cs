using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreeNode : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual DecisionTreeNode MakeDecision()
    {
        return null;
    }
}
