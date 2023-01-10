using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : IControllerAbillities
{
    private float _forgeDown;
    private Rigidbody2D _rigidbody2D;

    public Down(float forgeDown, Rigidbody2D rigidbody2D)
    {
        _forgeDown = forgeDown;
        _rigidbody2D = rigidbody2D;
    }

    public void StartDown()
    {
        _rigidbody2D.AddForce(new Vector2(0f, -1 * _forgeDown), ForceMode2D.Impulse);
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void Open()
    {
        throw new System.NotImplementedException();
    }
}
