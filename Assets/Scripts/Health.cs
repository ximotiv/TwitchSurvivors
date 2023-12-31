using System;

public class Health : IDamageable
{
    public event Action<int> OnTakedDamage;
    public event Action OnHealthChanged;
    public event Action OnHealthOver;
    public event Action OnImmunityDamage;

    public readonly int OriginalMaxHealth = 100;
    public int CurrentValue => _health;
    public int MaxValue => _maxHealth;
    
    private int _immunityFromShots;
    private int _maxHealth;
    private int _health;

    public int Immunity => _immunityFromShots;

    public Health(int immunityFromShots = 0)
    {
        _immunityFromShots = immunityFromShots;
    }

    public void SetImmunity(int countShots)
    {
        if (countShots < 1 || countShots > 5) return;
        _immunityFromShots = countShots;
    }

    public void SetMaxHealth(int value, bool setCurrentHealthToMax)
    {
        if (value < 2 || value > 15000) return;
        _maxHealth = value;

        if (setCurrentHealthToMax)
        {
            SetHealth(value);
        }
        else
        {
            OnHealthChanged?.Invoke();
        }
    }

    public void SetHealth(int value)
    {
        if (value < 1) return;

        _health = value > _maxHealth ? _maxHealth : value;
        OnHealthChanged?.Invoke();
    }

    public void GiveHealth(int value) => SetHealth(_health + value);

    public void TakeDamage(int value)
    {
        if(_immunityFromShots > 0)
        {
            _immunityFromShots--;
            OnImmunityDamage?.Invoke();
        }
        else
        {
            _health -= value;
            OnTakedDamage?.Invoke(value);

            if (_health <= 0)
            {
                _health = 0;
                OnHealthOver?.Invoke();
            }
        }
    }

    public void Regenerate()
    {
        int value = (int) (PlayerData.GetPropertieValue(PlayerData.Properties.Regeneration) / 100f * _maxHealth);
        GiveHealth(value);
    }
}
