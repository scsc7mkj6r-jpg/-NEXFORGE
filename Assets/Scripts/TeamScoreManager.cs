using UnityEngine;
using System;

public class TeamScoreManager : MonoBehaviour
{
    public static TeamScoreManager Instance { get; private set; }

    public int AlphaScore { get; private set; }
    public int BravoScore { get; private set; }

    public int scoreLimit = 100;

    public event Action<int, int> OnScoreChanged;
    public event Action<string> OnTeamWon;

    private bool matchEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddPoint(string teamName, int points = 1)
    {
        if (matchEnded || points <= 0)
            return;

        if (teamName == "Alpha")
            AlphaScore += points;
        else if (teamName == "Bravo")
            BravoScore += points;
        else
            return;

        OnScoreChanged?.Invoke(AlphaScore, BravoScore);

        if (AlphaScore >= scoreLimit)
            DeclareWinner("Alpha");
        else if (BravoScore >= scoreLimit)
            DeclareWinner("Bravo");
    }

    private void DeclareWinner(string teamName)
    {
        matchEnded = true;
        OnTeamWon?.Invoke(teamName);

        if (MatchManager.Instance != null)
            MatchManager.Instance.FinishMatch();
    }

    public void ResetScores()
    {
        AlphaScore = 0;
        BravoScore = 0;
        matchEnded = false;

        OnScoreChanged?.Invoke(AlphaScore, BravoScore);
    }
}