
public class DumplingsPlate : PropertyItem
{
    public override void Init()
    {
        Name = "������� ���������";
        CurrentPrice = 40;

        AddPropertie(PlayerData.Properties.Regeneration, 15);
        AddPropertie(PlayerData.Properties.MoveSpeed, -5);
    }
}
