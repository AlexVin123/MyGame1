using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventSpawner
{
    public static UnityAction EndWave;
    public static UnityAction EndSpawn;
    public static UnityAction<float, float> ChaingeProgress;
}
