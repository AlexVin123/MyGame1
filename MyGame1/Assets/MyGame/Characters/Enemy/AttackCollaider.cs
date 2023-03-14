using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollaider : MonoBehaviour
{
    private Player _player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.transform.TryGetComponent(out Player player))
        {
            _player = player;
        }
    }

    public void Attack(float damage)
    {
        if(_player != null)
        {
            _player.TakeDamage(damage);
            _player = null;
        }
    }
}
