using System;

public class Timer
{
    public event Action<float> OnTimerValueChangedEvent;
    public event Action OnTimerFinishedEvent;

    public bool IsPaused { get; private set; }
    public TimerType Type { get; private set; }
    public float RemainingSecond { get; private set; }

    public Timer(TimerType type) 
    {
        Type = type;
    }

    public Timer(TimerType type, float seconds)
    {
        Type = type;
        SetTime(seconds);
    }

    public bool TryEmpty()
    {
        if (OnTimerFinishedEvent == null)
            return true;
        else
            return false;
    }

    public void SetTime(float seconds)
    {
        RemainingSecond = seconds;
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);
    }

    public void Start()
    {
        if(RemainingSecond == 0)
        {
            OnTimerFinishedEvent?.Invoke();
        }

        IsPaused = false;
        Subscribe();
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);
    }

    public void Start(float seconds)
    {
        SetTime(seconds);
        Start();
    }

    public void Pause()
    {
        IsPaused = true;
        Unsubscrbe();
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);
    }

    public void UnPause()
    {
        IsPaused = false;
        Subscribe();
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);
    }

    public void Stop()
    {
        Unsubscrbe();
        RemainingSecond = 0;
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        OnTimerFinishedEvent?.Invoke();
    }

    private void Subscribe()
    {
        switch(Type)
        {
            case TimerType.UpdateTick:
                TimerInvoker.Instance.OnUpdateTimeTickedEvent += OnUpdateTick;
                break;
            case TimerType.UpdateTickUnscaled:
                TimerInvoker.Instance.OnUpdateTimeUnscaledTickedEvent += OnUpdateTick;
                break;
            case TimerType.OneSecTick:
                TimerInvoker.Instance.OnOneSecondTimeTickedEvent += OnOneSecTick;
                break;
            case TimerType.OneSecTickUnscaled:
                TimerInvoker.Instance.OnOnSecondUnscaledTickedEvent += OnOneSecTick;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Unsubscrbe() 
    {
        switch (Type)
        {
            case TimerType.UpdateTick:
                TimerInvoker.Instance.OnUpdateTimeTickedEvent -= OnUpdateTick;
                break;
            case TimerType.UpdateTickUnscaled:
                TimerInvoker.Instance.OnUpdateTimeUnscaledTickedEvent -= OnUpdateTick;
                break;
            case TimerType.OneSecTick:
                TimerInvoker.Instance.OnOneSecondTimeTickedEvent -= OnOneSecTick;
                break;
            case TimerType.OneSecTickUnscaled:
                TimerInvoker.Instance.OnOnSecondUnscaledTickedEvent -= OnOneSecTick;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnUpdateTick(float deltaTime)
    {
        if (IsPaused)
            return;

        RemainingSecond -= deltaTime;
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);

        if(CheckFinish())
        {
            Stop();
        }
    }

    private void OnOneSecTick()
    {
        if (IsPaused)
            return;

        RemainingSecond -= 1f;
        OnTimerValueChangedEvent?.Invoke(RemainingSecond);

        if(CheckFinish())
        {
            Stop();
        }
    }

    private bool CheckFinish()
    {
        if (RemainingSecond <= 0)
            return true;
        else
            return false;
    }
}
