
public class SkillzorIsland : PropertyItem
{
    public override void Init()
    {
        Name = "������ ��������";
        CurrentPrice = 25;

        AddPropertie(PlayerData.Properties.AttackSpeed, 25);
        AddPropertie(PlayerData.Properties.Dodge, -10);
    }
}
