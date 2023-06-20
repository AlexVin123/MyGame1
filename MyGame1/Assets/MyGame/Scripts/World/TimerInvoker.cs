using System;
using UnityEngine;

public class TimerInvoker : MonoBehaviour
{
    private static TimerInvoker _instance;
    private float _onSecTimer;
    private float _onSecUnscaledTimer;

    public event Action<float> UpdateTimeTicked;
    public event Action<float> UpdateTimeUnscaledTicked;
    public event Action OneSecondTimeTicked;
    public event Action OneSecondUnscaledTicked;

    public static TimerInvoker Instance
    {
        get
        {
            if(_instance == null)
            {
                var gameObject = new GameObject("[TIMER INVOKER]");
                _instance = gameObject.AddComponent<TimerInvoker>();
                DontDestroyOnLoad(gameObject);

            }

            return _instance;
        }
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        UpdateTimeTicked?.Invoke(deltaTime);
        _onSecTimer += deltaTime;

        if(_onSecTimer >= 1f)
        {
            _onSecTimer -= 1f;
            OneSecondTimeTicked?.Invoke();
        }

        var unscaledDeltaTime = Time.unscaledDeltaTime;
        UpdateTimeUnscaledTicked?.Invoke(unscaledDeltaTime);
        _onSecUnscaledTimer += unscaledDeltaTime;

        if(_onSecUnscaledTimer >= 1f)
        {
            _onSecUnscaledTimer -= 1f;
            OneSecondUnscaledTicked?.Invoke();
        }
    }
}
