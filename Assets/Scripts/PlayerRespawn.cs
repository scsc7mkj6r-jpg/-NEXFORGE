using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;
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

        if (spawnPoint != null)
        {
            if (controller != null)
                controller.enabled = false;

            transform.SetPositionAndRotation(
                spawnPoint.position,
                spawnPoint.rotation
            );

            if (controller != null)
                controller.enabled = true;
        }

        health.ResetHealth();
        isRespawning = false;
    }
}