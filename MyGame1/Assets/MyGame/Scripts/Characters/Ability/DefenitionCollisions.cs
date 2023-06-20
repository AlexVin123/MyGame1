using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefenitionCollisions : MonoBehaviour
{
    [SerializeField] private float _distansCheckDown;
    [SerializeField] private ContactFilter2D _filter;

    private Rigidbody2D _rigidbody2D;

    public void Init()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public bool GroundCheck()
    {
        var hit = new RaycastHit2D[1];
        var countCollision = _rigidbody2D.Cast(-transform.up,_filter, hit, _distansCheckDown);
        return hit[0];
    }

    public bool ReyCastDown(float distanse)
    {
        var hit = new RaycastHit2D[1];
        Physics2D.Raycast(transform.position, -Vector2.up, _filter, hit, distanse);
        return hit[0];
    }
}
