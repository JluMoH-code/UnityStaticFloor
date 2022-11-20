
// описывает изменения состояний при условии, что противник силён

public class CEnemyStrong : Condition
{
    private bool isEnemyStrong = false;

    public override bool Test()
    {
        if (isEnemyStrong)
            return true;
        return false;
    }
}
