using System;

public class Timer
{
    public event Action<float> TimerValueChanged;
    public event Action TimerFinished;

    public bool IsPaused { get; private set; }
    public TypeTimer Type { get; private set; }
    public float RemainingSecond { get; private set; }

    public Timer(TypeTimer type) 
    {
        Type = type;
    }

    public Timer(TypeTimer type, float seconds)
    {
        Type = type;
        SetTime(seconds);
    }

    public void SetTime(float seconds)
    {
        RemainingSecond = seconds;
        TimerValueChanged?.Invoke(RemainingSecond);
    }

    public void Start()
    {
        if(RemainingSecond == 0)
        {
            TimerFinished?.Invoke();
        }

        IsPaused = false;
        Subscribe();
        TimerValueChanged?.Invoke(RemainingSecond);
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
        TimerValueChanged?.Invoke(RemainingSecond);
    }

    public void UnPause()
    {
        IsPaused = false;
        Subscribe();
        TimerValueChanged?.Invoke(RemainingSecond);
    }

    public void Stop()
    {
        Unsubscrbe();
        RemainingSecond = 0;
        TimerValueChanged?.Invoke(RemainingSecond);
        TimerFinished?.Invoke();
    }

    private void Subscribe()
    {
        switch(Type)
        {
            case TypeTimer.UpdateTick:
                TimerInvoker.Instance.UpdateTimeTicked += OnUpdateTick;
                break;
            case TypeTimer.UpdateTickUnscaled:
                TimerInvoker.Instance.UpdateTimeUnscaledTicked += OnUpdateTick;
                break;
            case TypeTimer.OneSecTick:
                TimerInvoker.Instance.OneSecondTimeTicked += OnOneSecTick;
                break;
            case TypeTimer.OneSecTickUnscaled:
                TimerInvoker.Instance.OneSecondUnscaledTicked += OnOneSecTick;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Unsubscrbe() 
    {
        switch (Type)
        {
            case TypeTimer.UpdateTick:
                TimerInvoker.Instance.UpdateTimeTicked -= OnUpdateTick;
                break;
            case TypeTimer.UpdateTickUnscaled:
                TimerInvoker.Instance.UpdateTimeUnscaledTicked -= OnUpdateTick;
                break;
            case TypeTimer.OneSecTick:
                TimerInvoker.Instance.OneSecondTimeTicked -= OnOneSecTick;
                break;
            case TypeTimer.OneSecTickUnscaled:
                TimerInvoker.Instance.OneSecondUnscaledTicked -= OnOneSecTick;
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
        TimerValueChanged?.Invoke(RemainingSecond);

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
        TimerValueChanged?.Invoke(RemainingSecond);

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
