using UnityEngine;

public class Coggers : Weapon, IChargesUser
{
    [SerializeField] private Vector2[] _positionsForCoggers;
    private readonly float _rotationSpeed = 200f;

    public override void Init()
    {
        Name = "COGGERS";
        BasicPrice = CurrentPrice = 50;

        SetDamage(5);
        SetCooldown(10f);
        ChargesCount = 2;

        CreateCharges(Damage, true);
        UpdatePositionForCoggers();
    }

    private void FixedUpdate()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }

    public void Shoot(IEnemyCounter enemyDetection)
    {
        if (Time.time < CurrentCooldown) return;

        foreach (Bullet charge in ChargesList)
        {
            charge.Shoot(Vector2.zero, null, 0);
        }

        ActivateCooldown();
    }

    public override void Improve()
    {
        if (ImprovementLevel >= MAX_IMPROVE_LEVEL) return;
        ImprovementLevel++;

        switch (ImprovementLevel)
        {
            case 1:
                SetCooldown(9f);
                SetDamage(10);
                CreateCharge(Damage, true);
                UpdatePositionForCoggers();
                break;

            case 2:
                SetCooldown(8f);
                CreateCharge(Damage, true);
                UpdatePositionForCoggers();
                break;

            case 3:
                SetCooldown(6f);
                SetDamage(15);
                UpdatePositionForCoggers();
                break;

            case 4:
                
                SetDamage(20);
                break;
        }

        UpdatePrice();
        UpdateChargesDamage();
    }

    private void UpdatePositionForCoggers()
    {
        for (int i = 0; i < ChargesList.Count; i++)
        {
            Cogger cogger = (Cogger)ChargesList[i];
            cogger.SetPosition(_positionsForCoggers[i]);
        }
    }
}
