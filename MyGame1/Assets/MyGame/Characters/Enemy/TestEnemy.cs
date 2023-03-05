using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    private MovementDirectionX _movement;

    public override void Init()
    {
        base.Init();
        _movement = new MovementDirectionX(90f,Rigidbody);
    }

    public override void Attack()
    {
        
    }

    public override void Move(Vector2 positiont)
    {
        _movement.Move(Noramalize(positiont));
    }

    private float Noramalize(Vector2 position)
    {
        if (transform.position.x - position.x > 0)
            return -1;
        else
            return 1;
    }
}
