using UnityEngine;

public class DogEnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource _step;
    [SerializeField] private AudioSource _attack;

    public void PlayStep()
    {
        float pitch = Random.Range(0.8f, 1.2f);
        _step.pitch = pitch;
        _step.Play();
    }

    public void PlayAttack()
    {
        _attack.Play();
    }
}
