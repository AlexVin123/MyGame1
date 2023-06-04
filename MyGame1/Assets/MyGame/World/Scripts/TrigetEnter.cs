using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigetEnter : MonoBehaviour
{
    public UnityEvent _enter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enter?.Invoke();
        gameObject.SetActive(false);
    }
}