using UnityEngine;
using UnityEngine.InputSystem;
public class SistemaPausa : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject TextoPausa;
    private bool juegoPausado = false;
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) // Detectar teclado
        {
            CambiarPausa();
        }
        if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame) // Detectar mando
        {
            CambiarPausa();
        }
    }

    void CambiarPausa()
    {
        juegoPausado = !juegoPausado;

        if (juegoPausado)
        {
            Time.timeScale = 0f;
            TextoPausa.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            TextoPausa.SetActive(false);
        }
    }
}
