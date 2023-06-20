using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    void Move(Vector2 directoin);

    void Jump();

    void Burst(Vector2 direction);

    void Down();

    void Shoot();

    void Aim(Vector2 mousePosition);
}
