public class GlassesEZ : Item
{
    public override void Init()
    {
        ItemName = "���� EZ";
        Price = 250;

        AddPropertie(PlayerData.Properties.Damage, 3);
        AddPropertie(PlayerData.Properties.Armor, 3);
        AddPropertie(PlayerData.Properties.AttackSpeed, 3);
        AddPropertie(PlayerData.Properties.CriticalDamage, 3);
        AddPropertie(PlayerData.Properties.AttackDistance, 3);
    }
}