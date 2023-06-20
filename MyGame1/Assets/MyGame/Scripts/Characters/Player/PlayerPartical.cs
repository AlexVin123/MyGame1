using UnityEngine;

public class PlayerPartical : MonoBehaviour
{
    [SerializeField] private ParticleSystem _burstDown;
    [SerializeField] private ParticleSystem _exlosion;

    public void PlayBursDown()
    {
        _burstDown?.Play();
    }

    public void StopBurstDown()
    {
        _burstDown?.Stop();
    }

    public void PlayExplose()
    {
        _exlosion?.Play();
    }
}
