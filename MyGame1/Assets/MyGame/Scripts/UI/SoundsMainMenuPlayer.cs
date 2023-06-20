using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMainMenuPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _dirt;
    [SerializeField] private AudioSource _walk;
    [SerializeField] private AudioSource _reload;

    public void Play()
    {
        if (_dirt != null)
            _dirt.Play();
    }

    public void PlayWalk()
    {
        _walk.Play();
        StartCoroutine(RandomPitch());
    }

    public void StopWalk()
    {
        _walk.Stop();
        StopCoroutine(RandomPitch());
    }

    public void PlayReload()
    {
        _reload.Play();
    }

    private IEnumerator RandomPitch()
    {
        while (true)
        {
            _walk.pitch = Random.Range(0.8f, 1.2f);
            yield return new WaitForSeconds(_walk.clip.length);
        }
    }
}
