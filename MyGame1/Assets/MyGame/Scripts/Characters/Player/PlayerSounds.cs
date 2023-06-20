using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _step;
    [SerializeField] private AudioSource _burst;
    [SerializeField] private AudioSource _explousion;

    public void PlayStep()
    {
        float pitch = Random.Range(0.8f, 1.2f);
        _step.pitch = pitch;
        _step?.Play();
    }

    public void PlayBurst()
    {
        _burst?.Play();
    }

    public void PlayExplousing()
    {
        _explousion?.Play();
    }
}
