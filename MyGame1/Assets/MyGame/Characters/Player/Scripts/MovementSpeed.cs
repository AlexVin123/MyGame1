using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New parametrs speed",menuName = "Abillities/Movements")]
public class MovementSpeed : Abillity
{
    [SerializeField] private float _maxSpeed;

    public float MaxSpeed => _maxSpeed;
}
