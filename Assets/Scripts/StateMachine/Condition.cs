using UnityEngine;


// абстрактный класс, отвечающий за выполнение условия перехода из одного состояния в другое

public class Condition : MonoBehaviour
{
    public virtual bool Test()
    {
        return false;
    }
}
