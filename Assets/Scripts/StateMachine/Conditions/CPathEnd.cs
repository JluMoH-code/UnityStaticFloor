
// ��������� ��������� ��������� ��� �������, ��� ��������� ���������

public class CPathEnd : Condition
{
    public override bool Test()
    {
        if (IsPathEnd())
            return true;
        return false;
    }

    bool IsPathEnd()
    {
        return false;
    }
}
