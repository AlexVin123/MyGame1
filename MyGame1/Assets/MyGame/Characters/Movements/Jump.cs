using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IControllerAbillities
{
    private float _forgeJump;
    private Rigidbody2D _rigidbody2D;

    public Jump(float forgeJump, Rigidbody2D rigidbody2D)
    {
        _forgeJump = forgeJump;
        _rigidbody2D = rigidbody2D;
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void Open()
    {
        throw new System.NotImplementedException();
    }

    public void StartJump()
    {
        _rigidbody2D.AddForce(new Vector2(0f, 1 * _forgeJump), ForceMode2D.Impulse);
    }
}
