using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenitionCollisions : MonoBehaviour
{
    [SerializeField] private float _distansCheckDown;

    private Rigidbody2D _rigidbody2D;

    public bool IsGround { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GroundCheck();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        var hit = new RaycastHit2D[1];
        var countCollision = _rigidbody2D.Cast(-transform.up, hit, _distansCheckDown);
        Debug.Log(countCollision > 0);
        IsGround = countCollision > 0;
    }
}
