using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonUpgrade : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TypeParameter _typeParameter;

    public UnityAction<TypeParameter> Action;

    public Button Button => _button;

    public void Init(TypeParameter typeParameter, Sprite image)
    {
        _typeParameter = typeParameter;
        _button.image.sprite = image;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Action?.Invoke(_typeParameter);
    }
}
