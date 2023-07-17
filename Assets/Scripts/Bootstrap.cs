using UnityEngine;
using Zenject;

public sealed class Bootstrap : MonoBehaviour
{
    [Inject] private readonly PlayerUnit _playerUnit;
    [Inject] private readonly EnemyFactory _enemyFactory;
    [Inject] private readonly TwitchIntegration _twitch;
    [Inject] private readonly BitsController _bits;

    [SerializeField] private Collider2D _spawnArea;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PlayerInterface _playerUI;
    [SerializeField] private ShopController _shop;

    private EnemySpawner _enemySpawner;
    private CameraShaker _cameraShaker;
    private CombineEnemyAndTwitch _combineEnemyAndTwitch;

    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = new();
        _playerData.Init();

        _playerUnit.Init();

        _playerUI.Init();

        _enemySpawner = new(this, _enemyFactory, _playerUnit.transform, _spawnArea);
        _enemySpawner.Init();

        _cameraShaker = new(_playerUnit);
        _cameraShaker.Init();

        _playerBehaviour.Init();

        _combineEnemyAndTwitch = new(_twitch, _enemySpawner);
        _combineEnemyAndTwitch.Init();

        _bits.Init();

        _shop.Init();
    }
}
