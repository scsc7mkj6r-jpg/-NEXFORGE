using UnityEngine;

[RequireComponent(typeof(TeamMember))]
public class PlayerTeamSpawner : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;

    public bool SpawnPlayer(GameObject player)
    {
        if (player == null || spawnManager == null)
            return false;

        TeamMember member = player.GetComponent<TeamMember>();

        if (member == null)
            return false;

        Transform point = spawnManager.GetSpawnPoint(member.TeamName);

        if (point == null)
        {
            Debug.LogError("NEXFORGE: Spawn point not found for " + member.TeamName);
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

        return true;
    }
}