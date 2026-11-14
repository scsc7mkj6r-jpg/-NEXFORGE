using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager Instance { get; private set; }

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

    public bool IsSameTeam(string firstTeam, string secondTeam)
    {
        if (string.IsNullOrEmpty(firstTeam) ||
            string.IsNullOrEmpty(secondTeam))
            return false;

        return firstTeam == secondTeam;
    }
}