
// ��������� ��������� ��������� ��� �������, ��� ������ ��������� �����

public class CTimeOut : Condition
{

    public override bool Test()
    {
        if (IsTimeOut())
            return true;
        return false;
    }

    private bool IsTimeOut()
    {
        return false;
    }
}
