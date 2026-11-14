using UnityEngine;

public class PlayerTeamSpawner : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private string teamName = "Alpha";

    public bool SpawnPlayer(GameObject player)
    {
        if (player == null || spawnManager == null)
            return false;

        Transform point = spawnManager.GetSpawnPoint(teamName);

        if (point == null)
        {
            Debug.LogError("NEXFORGE: Team spawn point not found!");
            return false;
        }

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        player.transform.SetPositionAndRotation(
            point.position,
            point.rotation
        );

        if (controller != null)
            controller.enabled = true;

        TeamMember member = player.GetComponent<TeamMember>();

        if (member != null)
            member.SetTeam(teamName);

        return true;
    }
}