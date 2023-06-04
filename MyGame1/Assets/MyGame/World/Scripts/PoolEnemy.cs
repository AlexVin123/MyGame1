using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolEnemy
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _count;

    private PoolMono<Enemy> _pool;

    public void Init(Transform conteiner, ITarget target = null)
    {
        _pool = new PoolMono<Enemy>(_prefab, _count, conteiner);
        var allEnemy = _pool.GetAllElements();

        foreach (Enemy enemy in allEnemy)
        {
            enemy.Init(target);
        }
    }

    public Enemy Spawn(Vector2 position)
    {
        return _pool.GetFreeElement(position);
    }
}
