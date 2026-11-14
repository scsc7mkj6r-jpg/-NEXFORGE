using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(TeamMember))]
public class PlayerRespawn : MonoBehaviour
{
    public SpawnManager spawnManager;
    public float respawnDelay = 3f;

    private PlayerHealth health;
    private TeamMember teamMember;
    private CharacterController controller;
    private bool isRespawning;

    private void Awake()
    {
        health = GetComponent<PlayerHealth>();
        teamMember = GetComponent<TeamMember>();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        health.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        if (!isRespawning)
            StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        isRespawning = true;

        yield return new WaitForSeconds(respawnDelay);

        Transform point = spawnManager != null
            ? spawnManager.GetSpawnPoint(teamMember.TeamName)
            : null;

        if (point == null)
        {
            Debug.LogError("NEXFORGE: Team spawn point not found!");
            isRespawning = false;
            yield break;
        }

        if (controller != null)
            controller.enabled = false;

        transform.SetPositionAndRotation(point.position, point.rotation);

        if (controller != null)
            controller.enabled = true;

        health.ResetHealth();
        isRespawning = false;
    }
}