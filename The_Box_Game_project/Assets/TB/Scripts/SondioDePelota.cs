using UnityEngine;

public class SondioDePelota : MonoBehaviour
{
    [Header("Referencias")]
    public AudioSource audioSource;
    private Rigidbody rb;

    [Header("Ajustes de Velocidad")]
    [Tooltip("Velocidad mínima para que empiece a sonar")]
    public float velocidadMinima = 0.2f;
    [Tooltip("Velocidad a la que el sonido alcanza su volumen/pitch máximo")]
    public float velocidadMaxima = 8.0f;

    [Header("Ajustes de Sonido")]
    [Range(0f, 1f)] public float volumenMaximo = 1f;
    public float pitchMinimo = 0.8f;
    public float pitchMaximo = 1.4f;

    private bool enContacto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (audioSource == null)
        audioSource = GetComponent<AudioSource>();        
        audioSource.loop = true;
        audioSource.volume = 0f;
        audioSource.Play();
    }

    void Update()
    {
        // En Unity 6 se usa linearVelocity; en versiones anteriores (Unity 2022 o anterior) usa rb.velocity
#if UNITY_6000_0_OR_NEWER
        float velocidadActual = rb.linearVelocity.magnitude;
#else
        float velocidadActual = rb.velocity.magnitude;
#endif

        // Solo suena si la pelota está tocando la plataforma y se mueve más rápido que el umbral
        if (enContacto && velocidadActual > velocidadMinima)
        {
            // Calculamos un factor entre 0 y 1 según la velocidad
            float factor = Mathf.InverseLerp(velocidadMinima, velocidadMaxima, velocidadActual);

            // Ajustamos el volumen y el tono según qué tan rápido ruede
            audioSource.volume = Mathf.Lerp(0f, volumenMaximo, factor);
            audioSource.pitch = Mathf.Lerp(pitchMinimo, pitchMaximo, factor);
        }
        else
        {
            // Si frena o está en el aire, desvanecemos el volumen suavemente
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, 0f, Time.deltaTime * 5f);
        }
    }

    // Detectamos si la pelota está tocando la plataforma
    private void OnCollisionStay(Collision col)
    {
        // Opcional: puedes filtrar para que solo suene con la plataforma asignándole un Tag
        // if (col.gameObject.CompareTag("Plataforma"))
        enContacto = true;
    }

    private void OnCollisionExit(Collision col)
    {
        enContacto = false;
    }
}