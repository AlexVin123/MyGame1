using UnityEngine;

[System.Serializable]
public class EnemysInWave
{
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private int _count;

    public EnemyType EnemyType => _enemyType;
    public int Count => _count;
}
