using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParticalController
{
    public void PlayPartical(int indexInArray);
    public void Stop(int indexInArray);
    public void StartAll();

    public void StopAll();
}
