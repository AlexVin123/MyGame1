using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PhusicsButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private UnityEvent _mouseEnter;
    [SerializeField] private UnityEvent _mouseDown;
    [SerializeField] private BoxCollider2D _boxCollider;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
        _mouseEnter?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("MouseDown");
        _mouseDown?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
