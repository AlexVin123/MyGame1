using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TargetSearch : MonoBehaviour
{
    public event Action<ITarget> OnTargetEnteredEvent;
    public event Action<ITarget> OnTargetExitedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            OnTargetEnteredEvent?.Invoke(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            OnTargetExitedEvent?.Invoke(target);
        }
    }



}
