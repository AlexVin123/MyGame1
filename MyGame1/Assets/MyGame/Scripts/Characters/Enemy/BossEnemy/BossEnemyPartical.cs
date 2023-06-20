using UnityEngine;

public class BossEnemyPartical : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explousing;
    [SerializeField] private Explosion _explosion;

    private void OnEnable()
    {
        if (_explousing != null && _explosion != null)
            _explosion.StartedExplosion += _explousing.Play;
    }

    private void OnDisable()
    {
        if (_explousing != null && _explosion != null)
            _explosion.StartedExplosion -= _explousing.Play;
    }


}
