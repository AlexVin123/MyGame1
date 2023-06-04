using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transit:ScriptableObject
{
   [SerializeField] private TypeState _state;

    public TypeState State => _state;

    public abstract bool NeedTransit(Enemy enemy);
}
