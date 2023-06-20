using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    Vector2 Position { get;}

    Vector2 LuckDirection { get;}

    TypeTarget TargetType { get;}

    void TakeDamage(float damage);

    float MaxHealth { get; }
}
