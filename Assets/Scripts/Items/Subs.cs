

public class Subs : PropertyItem
{
    public override void Init()
    {
        ItemName = "�����";
        Price = 500;

        AddPropertie(PlayerData.Properties.Damage, 5);
        AddPropertie(PlayerData.Properties.AttackSpeed, 5);
        AddPropertie(PlayerData.Properties.CriticalDamage, 5);
        AddPropertie(PlayerData.Properties.Distance, 5);
    }
}
