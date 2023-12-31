using UnityEngine;

public class BibleThump : Enemy
{
    [SerializeField] private TearPool _tearPoolPrefab;

    private TearPool _tearPool;

    public override void Init()
    {
        base.Init();
        CreateTearPool();
    }

    private void CreateTearPool()
    {
        _tearPool = Instantiate(_tearPoolPrefab, null);
        _tearPool.Init(Damage);
        _tearPool.gameObject.SetActive(false);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        _tearPool.Shoot(transform.position, null, 0);
    }
}
