using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    [SerializeField] private Bar _healthBar;
    private Enemy _enemyBoss;
    private bool _bossIsTry = false;

    private void Update()
    {
        if (_bossIsTry == false)
            _enemyBoss = FindEnemyBoss();

        if (_enemyBoss != null)
            _enemyBoss.ChaigedHealth += _healthBar.ChaingeBar;
    }

    private void OnDisable()
    {
        _enemyBoss.ChaigedHealth -= _healthBar.ChaingeBar;
    }

    public Enemy FindEnemyBoss()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        foreach (Enemy enemy in enemies)
        {
            if (enemy.TargetType == TypeTarget.EnemyBoss)
            {
                _bossIsTry = true;
                return enemy;
            }
        }
        return null;
    }
}
