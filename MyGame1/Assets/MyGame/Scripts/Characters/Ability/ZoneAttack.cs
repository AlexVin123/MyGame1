using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneAttack : MonoBehaviour
{
    public ITarget Target { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITarget target))
            Target = target;
        else
            Target = null;
    }
}
