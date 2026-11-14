using UnityEngine;

public class TeamMember : MonoBehaviour
{
    [SerializeField]
    private string teamName = "Alpha";

    public string TeamName => teamName;

    public void SetTeam(string newTeam)
    {
        if (string.IsNullOrWhiteSpace(newTeam))
            return;

        teamName = newTeam;
    }

    public bool IsOnSameTeam(TeamMember other)
    {
        return other != null && teamName == other.teamName;
    }
}