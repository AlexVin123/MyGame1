using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PhusicsButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private UnityEvent _mouseEnter;
    [SerializeField] private UnityEvent _mouseDown;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseEnter?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mouseDown?.Invoke();
    }
}
