
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si ha tocado un obstáculo
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Recuperar la posición inicial
        transform.position = respawnPoint.position;

        // Detener el movimiento de la pelota
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
