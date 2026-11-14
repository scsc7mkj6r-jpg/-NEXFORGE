using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints;

    public Transform GetSpawnPoint(string teamName)
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
            return null;

        foreach (SpawnPoint point in spawnPoints)
        {
            if (point != null && point.teamName == teamName)
                return point.transform;
        }

        return null;
    }

    public bool HasSpawnPoint(string teamName)
    {
        return GetSpawnPoint(teamName) != null;
    }
}