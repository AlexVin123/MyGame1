using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour, IParticalController
{
    [SerializeField] private ParticleSystem[] _particles;

    public void PlayPartical(int indexInArray)
    {
        if(indexInArray >= _particles.Length || indexInArray < 0)
            return;

        _particles[indexInArray].Play();
    }

    public void StartAll()
    {
        if(_particles != null)
            foreach(var particle in _particles)
                particle.Play();
    }

    public void Stop(int indexInArray)
    {
        if (indexInArray >= _particles.Length || indexInArray < 0)
            return;

        _particles[indexInArray].Stop();
    }

    public void StopAll()
    {
        if (_particles != null)
            foreach (var particle in _particles)
                particle.Play();
    }
}
