using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    Vector2 Position();

    void TakeDamage(float damage);
}
