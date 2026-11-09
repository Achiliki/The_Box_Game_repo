using UnityEngine;
public class Respawn : MonoBehaviour
{
    [Header("Respawn System")]
    public Rigidbody pelota;
    public Transform respawnPoint;
    private void OnTriggerEnter(Collider other) // Por si el obstáculo SÍ es Trigger (Is Trigger activado)
    {
        if (other.CompareTag("obstacle"))
        {
            OnRespawn();
        }
    }

    void OnRespawn()
    {
        if (respawnPoint == null)
        {
            Debug.LogWarning("No has asignado el Respawn Point en el Inspector.");
            return;
        }

        if (pelota != null)
        {
            // Teletransportar el Rigidbody directamente
            pelota.position = respawnPoint.position;
            transform.position = respawnPoint.position;

            // Resetear velocidad lineal
            // (Si usas Unity 2022 o anterior, cambia linearVelocity por velocity)
            pelota.linearVelocity = Vector3.zero;

            // Resetear velocidad de giro para que no salga rodando sola
            pelota.angularVelocity = Vector3.zero;
        }
        else
        {
            transform.position = respawnPoint.position;
        }

        // Forzar actualización inmediata del motor de físicas
        Physics.SyncTransforms();
    }
}