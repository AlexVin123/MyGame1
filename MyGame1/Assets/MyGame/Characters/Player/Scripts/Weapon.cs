using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform Shotpoint;

    public abstract void Shoot();

    public abstract void Init(ICharacterConfig parameters);
}
