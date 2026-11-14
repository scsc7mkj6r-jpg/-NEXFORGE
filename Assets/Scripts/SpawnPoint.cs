using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnId;
    public string teamName = "Neutral";

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);

        Gizmos.DrawLine(
            transform.position,
            transform.position + transform.forward * 2f
        );
    }
}