using UnityEngine;
using System.Collections.Generic;

public class PlayerRegistry : MonoBehaviour
{
    private static readonly List<TeamMember> players =
        new List<TeamMember>();

    public static void RegisterPlayer(TeamMember player)
    {
        if (player == null || players.Contains(player))
            return;

        players.Add(player);
    }

    public static void UnregisterPlayer(TeamMember player)
    {
        if (player == null)
            return;

        players.Remove(player);
    }

    public static int GetPlayerCount()
    {
        players.RemoveAll(player => player == null);
        return players.Count;
    }

    public static int GetTeamCount(string teamName)
    {
        players.RemoveAll(player => player == null);

        int count = 0;

        foreach (TeamMember player in players)
        {
            if (player.TeamName == teamName)
                count++;
        }

        return count;
    }

    public static List<TeamMember> GetPlayers()
    {
        players.RemoveAll(player => player == null);
        return new List<TeamMember>(players);
    }
}