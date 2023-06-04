using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float Damage;
    [SerializeField] protected float DistanceShot;
    [SerializeField] protected Transform Shotpoint;

    public abstract void Shoot();
}
