using UnityEngine;

public class TaranEnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource _stepSound;
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _burstSound;

    [SerializeField] private Burst _burst;
    [SerializeField] private OneAttackCollider _oneAttackCollider;

    public void PlayStep()
    {
        float pitch = Random.Range(0.8f, 1.2f);
        _stepSound.pitch = pitch;
        _stepSound?.Play();
    }

    public void PlayBurst()
    {
        _burstSound?.Play();
    }

    public void PlayAttack()
    {
        _attackSound?.Play();
    }

    private void OnEnable()
    {
        if (_oneAttackCollider != null)
            _oneAttackCollider.TakedDamage += PlayAttack;
    }

    private void OnDisable()
    {
        if (_oneAttackCollider != null)
            _oneAttackCollider.TakedDamage -= PlayAttack;
    }
}
