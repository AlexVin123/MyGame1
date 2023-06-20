using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ITarget player))
        {
            player.TakeDamage(900);
        }
    }
}
