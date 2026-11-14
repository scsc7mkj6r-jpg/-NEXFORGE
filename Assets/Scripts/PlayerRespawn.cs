using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerRespawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    public SpawnManager spawnManager;
    public string teamName = "Alpha";
    public float respawnDelay = 3f;

    private PlayerHealth health;
    private CharacterController controller;
    private bool isRespawning;

    private void Awake()
    {
        health = GetComponent<PlayerHealth>();
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
            ? spawnManager.GetSpawnPoint(teamName)
            : null;

        if (point == null)
        {
            Debug.LogError("NEXFORGE: Spawn point not found!");
            isRespawning = false;
            yield break;
        }

        if (controller != null)
            controller.enabled = false;

        transform.SetPositionAndRotation(
            point.position,
            point.rotation
        );

        if (controller != null)
            controller.enabled = true;

        health.ResetHealth();
        isRespawning = false;
    }
}