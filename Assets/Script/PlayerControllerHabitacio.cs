using UnityEngine;

public class PlayerControllerHabitacio : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip walkSound;
    private AudioSource audioSource;
    private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del usuario para el movimiento horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el movimiento en la dirección diagonal para la vista isométrica
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * (speed * Time.deltaTime);

        // Aplicar el movimiento al jugador
        transform.Translate(movement, Space.World);

        // Rotar el jugador hacia la dirección del movimiento
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Ajusta el último parámetro para controlar la velocidad de la rotación
        }

        // Reproducir el sonido de los pasos si el jugador se está moviendo
        if (movement.magnitude > 0.001f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(walkSound);
            }
            
            // Activar el estado "IsWalking" del Animator
            animator.SetBool(IsWalking, true);
        }
        else
        {
            audioSource.Stop();
            
            // Desactivar el estado "IsWalking" del Animator
            animator.SetBool(IsWalking, false);
        }
    }
}