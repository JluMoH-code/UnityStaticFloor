
// абстрактный класс, который описывает следующее положение 

/// <summary>
/// 
/// </summary>
public class Transition
{
    public Condition condition;
    public State targetState;

    /// <summary>
    ///  
    /// </summary>
    /// <param name="condition">Параметр, описывающий условие перехода</param>
    /// <param name="state"></param> 
    public Transition (Condition condition, State state)
    {

        this.condition = condition;
        this.targetState = state;
    }
}
