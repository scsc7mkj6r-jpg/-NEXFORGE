using UnityEngine;

public class PlayerTeamSpawner : MonoBehaviour
{
    public SpawnManager spawnManager;
    public string teamName = "Alpha";

    public void SpawnPlayer(GameObject player)
    {
        if (player == null || spawnManager == null)
            return;

        Transform spawnPoint = spawnManager.GetSpawnPoint(teamName);

        if (spawnPoint == null)
            return;

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        player.transform.SetPositionAndRotation(
            spawnPoint.position,
            spawnPoint.rotation
        );

        if (controller != null)
            controller.enabled = true;

        TeamMember member = player.GetComponent<TeamMember>();

        if (member != null)
            member.SetTeam(teamName);
    }
}