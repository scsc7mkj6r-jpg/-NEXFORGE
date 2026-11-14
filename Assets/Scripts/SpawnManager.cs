using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnPoint[] spawnPoints;

    public Transform GetSpawnPoint(string teamName)
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
            return null;

        foreach (SpawnPoint point in spawnPoints)
        {
            if (point != null && point.teamName == teamName)
                return point.transform;
        }

        return spawnPoints[0] != null
            ? spawnPoints[0].transform
            : null;
    }
}