using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonUpgrade : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TypeParameter _typeParameter;
    
    private Image _image;

    public UnityAction<TypeParameter> Action;

    public Button Button => _button;

    public void Init(TypeParameter typeParameter, Image image)
    {
        _typeParameter = typeParameter;
        _image = image;
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
        Action.Invoke(_typeParameter);
    }
}
