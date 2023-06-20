using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ResultGamePanel : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _loseHouse;
    [SerializeField] private Sprite _losePlayer;
    [SerializeField] private Sprite _winSprite;
    [SerializeField] private AudioSource _beckground;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;

    private Animator _animator;
    private int _triggerEndGame = Animator.StringToHash("GameEnd");
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void GameEnd()
    {
        Time.timeScale = 0;
        _beckground?.Stop();
        _animator.SetTrigger(_triggerEndGame);
    }

    public void OnDyingPlayer()
    {
        _loseSound?.Play();
        _icon.sprite = _losePlayer;
        GameEnd();
    }

    public void OnDyingHouse()
    {
        _loseSound?.Play();
        _icon.sprite = _loseHouse;
        GameEnd();
    }

    public void OnWin()
    {
        _winSound?.Play();
        _icon.sprite = _winSprite;
        GameEnd();
    }
}
