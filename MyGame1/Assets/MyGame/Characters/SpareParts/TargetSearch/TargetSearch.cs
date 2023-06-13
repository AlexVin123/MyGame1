using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TargetSearch : MonoBehaviour
{
    [SerializeField] private TypeTarget[] _filter;


    public event Action<ITarget> OnTargetEnteredEvent;
    public event Action<ITarget> OnTargetExitedEvent;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            if (_filter != null)
                if (CheckFilter(target))
                    OnTargetEnteredEvent?.Invoke(target);

            if (_filter == null)
                OnTargetEnteredEvent?.Invoke(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            if (_filter != null)
                if (CheckFilter(target))
                    OnTargetExitedEvent?.Invoke(target);

            if (_filter == null)
                OnTargetExitedEvent?.Invoke(target);
        }
    }

    private bool CheckFilter(ITarget target)
    {
        foreach (var value in _filter)
        {
            if (value == target.TargetType)
                return false;
        }

        return true;
    }



}
