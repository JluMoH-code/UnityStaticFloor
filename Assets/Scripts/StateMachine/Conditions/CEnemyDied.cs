
// ��������� ��������� ��������� ��� �������, ��� ��������� ����

public class CEnemyDied : Condition
{
    private bool isEnemyDied = false;

    public override bool Test()
    {
        if (isEnemyDied)
            return true;
        return false;
    }
}
