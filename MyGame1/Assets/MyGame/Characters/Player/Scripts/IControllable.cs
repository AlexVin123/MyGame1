using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    void Move(float directoinX);

    void Jump();

    void Burst(float directionX);

    void Down();
}
