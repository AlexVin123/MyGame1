using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemysInWave
{
    [SerializeField] private int _index;
    [SerializeField] private int _count;

    public int Index => _index;
    public int Count => _count;
}
