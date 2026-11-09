
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioClip sonido;

    private void Start()
    {
        Debug.Log("BALL SOUND INICIADO");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER DETECTADO CON: " + other.gameObject.name);

        if (other.CompareTag("ObjectoSonido"))
        {
            Debug.Log("OBJETO SONIDO DETECTADO");

            AudioSource.PlayClipAtPoint(sonido, transform.position);
        }
    }
}
