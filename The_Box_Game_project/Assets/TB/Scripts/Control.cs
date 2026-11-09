using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMaster : MonoBehaviour
{
    [Header("Bases")]
    private Rigidbody rb;
    private Vector2 movementInput;
    public float VelocidadRotacion = 50;
    public float AnguloMaximo = 15;
    private float rotacionAcumuladaX;
    private float rotacionAcumuladaZ;
    private Quaternion rotacionInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotacionInicial = rb.rotation;
    }
    void FixedUpdate()
    {
        rotacionAcumuladaX += movementInput.y * VelocidadRotacion * Time.fixedDeltaTime; // Acumulamos la rotación en los ejes X y Z
        rotacionAcumuladaZ -= movementInput.x * VelocidadRotacion * Time.fixedDeltaTime;
        rotacionAcumuladaX = Mathf.Clamp(rotacionAcumuladaX, -AnguloMaximo, AnguloMaximo); // Limitamos la inclinación máxima
        rotacionAcumuladaZ = Mathf.Clamp(rotacionAcumuladaZ, -AnguloMaximo, AnguloMaximo);
        Quaternion rotacionObjetivo = rotacionInicial * Quaternion.Euler(rotacionAcumuladaX, 0f, rotacionAcumuladaZ); // Creamos la rotación deseada
        rb.MoveRotation(rotacionObjetivo); // Aplicamos la rotación mediante el Rigidbody
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}

