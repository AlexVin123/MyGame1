using UnityEngine;

[System.Serializable]
public class PoolEnemy
{
    [SerializeField] private EnemyType _enemyIndex;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _count;

    private PoolMono<Enemy> _pool;

    public EnemyType EnemyIndex => _enemyIndex;

    public Enemy[] GetAllEnemy()
    {
        return _pool.GetAllElements();
    }

    public void Init(Transform conteiner, ITarget target = null)
    {
        _pool = new PoolMono<Enemy>(_prefab, _count, conteiner);
        var allEnemy = _pool.GetAllElements();

        foreach (Enemy enemy in allEnemy)
        {
            enemy.Init(null);
            enemy.OnTargetEnter(target);
        }
    }

    public Enemy Spawn(Vector2 position)
    {
        Enemy enemy = _pool.GetFreeElement(position);
        enemy.Reset();
        return enemy;
    }
}

public enum EnemyType
{
    EnemyDog, FlyEnemy, TaranEnemy, BossEnemy, Enemy5, Enemy6, Enemy7, Enemy8,
}
