
// описывает изменения состояний при условии, что обнаружено оружие

public class CWeaponDetect : Condition
{
    private bool isWeaponDetect = false;

    public override bool Test()
    {
        if (isWeaponDetect)
            return true;
        return false;
    }
}
