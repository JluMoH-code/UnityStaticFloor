
// ��������� ��������� ��������� ��� �������, ��� ��������� �������

public class CHelpFound : Condition
{
    private bool isHelpFound = false;

    public override bool Test()
    {
        if (isHelpFound)
            return true;
        return false;
    }
}
