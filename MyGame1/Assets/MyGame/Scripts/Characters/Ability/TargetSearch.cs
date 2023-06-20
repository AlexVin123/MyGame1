using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TargetSearch : MonoBehaviour
{
    [SerializeField] private TypeTarget[] _filter;

    public event UnityAction<ITarget> TargetEntered;
    public event UnityAction<ITarget> TargetExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            if (_filter != null)
                if (CheckFilter(target))
                    TargetEntered?.Invoke(target);

            if (_filter == null)
                TargetEntered?.Invoke(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITarget target))
        {
            if (_filter != null)
                if (CheckFilter(target))
                    TargetExited?.Invoke(target);

            if (_filter == null)
                TargetExited?.Invoke(target);
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
