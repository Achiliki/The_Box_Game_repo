using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody rb;
    public float fuerzaAdherencia = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtenemos el Rigidbody de la pelota
    }
    void OnCollisionStay(Collision collision)
    { 
        if (collision.contactCount > 0) // Comprobamos que exista un contacto físico
        {
            ContactPoint contacto = collision.GetContact(0); // Obtenemos el primer punto de contacto
            rb.AddForce(-contacto.normal * fuerzaAdherencia,ForceMode.Acceleration); // Empujamos la pelota hacia la superficie
        }
    }
}
