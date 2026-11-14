using UnityEngine;
using System;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance { get; private set; }

    public enum MatchState
    {
        Waiting,
        Starting,
        InProgress,
        Finished
    }

    public MatchState CurrentState { get; private set; }
    public float MatchDuration = 600f;

    private float remainingTime;

    public event Action<MatchState> OnStateChanged;
    public event Action<float> OnTimerUpdated;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        CurrentState = MatchState.Waiting;
    }

    public void StartMatch()
    {
        remainingTime = MatchDuration;
        ChangeState(MatchState.InProgress);
    }

    private void Update()
    {
        if (CurrentState != MatchState.InProgress)
            return;

        remainingTime -= Time.deltaTime;
        OnTimerUpdated?.Invoke(remainingTime);

        if (remainingTime <= 0f)
            FinishMatch();
    }

    public void FinishMatch()
    {
        if (CurrentState != MatchState.InProgress)
            return;

        remainingTime = 0f;
        ChangeState(MatchState.Finished);
    }

    public void ResetMatch()
    {
        remainingTime = MatchDuration;
        ChangeState(MatchState.Waiting);
    }

    private void ChangeState(MatchState newState)
    {
        CurrentState = newState;
        OnStateChanged?.Invoke(CurrentState);
    }
}