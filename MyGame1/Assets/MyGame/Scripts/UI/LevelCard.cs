using UnityEngine;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Button _button;
    [SerializeField] private int _idLvl;

    private Image _imageLvl;

    private void Awake()
    {
        _imageLvl = GetComponent<Image>();
        _imageLvl.sprite = _sprite;
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneTransition.SwithToScene(_idLvl);
    }
}
