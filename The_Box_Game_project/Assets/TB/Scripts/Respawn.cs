using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player") &&
            collision.gameObject.CompareTag("Obstaculo"))
        {
            ReiniciarNivel();
        }
    }

    void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}