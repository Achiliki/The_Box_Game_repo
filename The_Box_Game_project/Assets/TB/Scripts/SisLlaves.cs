using UnityEngine;

public class SisLlaves : MonoBehaviour
{
    public GameObject pared; // Aqui guardaremos la pared que queremos eliminar. La asignaremos desde el Inspector de Unity.
    private void OnTriggerEnter(Collider other) //Esta funcion se ejecuta cuando otro Collider. Entra en contacto con el Trigger de la llave.
    {
        if (other.CompareTag("Player")) // Comprobamos si el objeto que ha tocado la llave. Tiene la etiqueta Player.
        {
           pared.SetActive(false); // Desactivamos la parede. SetActive(false) hace que desaparezca de la escena.
           Destroy(gameObject); // Destruimos el objeto llave. Ya no podremos volver a recogerla.
        }
    }
}