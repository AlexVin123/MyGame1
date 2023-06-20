using UnityEngine;

public class BossEnemySounds : MonoBehaviour
{
    [SerializeField] private AudioSource _attackWave;
    [SerializeField] private AudioSource _step;
    [SerializeField] private AudioSource _summoningThunder;

    public void PlayAttackWave()
    {
        _attackWave?.Play();
    }

    public void PlayStep()
    {
        float pitch = Random.Range(0.8f, 1.2f);
        _step?.Play();
    }

    public void PlaySummoningThunder()
    {
        _summoningThunder?.Play();
    }

    public void StopSummoningThunder()
    {
        _summoningThunder?.Stop();
    }
}
