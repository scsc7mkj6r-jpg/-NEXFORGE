using UnityEngine;

public class TeamMember : MonoBehaviour
{
    [SerializeField]
    private string teamName = "Alpha";

    public string TeamName => teamName;

    private void OnEnable()
    {
        PlayerRegistry.RegisterPlayer(this);
    }

    private void OnDisable()
    {
        PlayerRegistry.UnregisterPlayer(this);
    }

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