using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }

    public string MatchId { get; private set; }
    public bool IsActive { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartSession(string matchId)
    {
        if (string.IsNullOrWhiteSpace(matchId))
            return;

        MatchId = matchId;
        IsActive = true;
    }

    public void EndSession()
    {
        IsActive = false;
        MatchId = null;
    }
}