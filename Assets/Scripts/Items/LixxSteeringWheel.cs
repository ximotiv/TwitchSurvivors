
public class LixxSteeringWheel : PropertyItem
{
    public override void Init()
    {
        ItemName = "���� �����";
        Price = 200;

        AddPropertie(PlayerData.Properties.Distance, 10);
        AddPropertie(PlayerData.Properties.MoveSpeed, 10);
        AddPropertie(PlayerData.Properties.AttackSpeed, 5);
    }
}
