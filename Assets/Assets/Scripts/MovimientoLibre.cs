using UnityEngine;

public class MovimientoLibre : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f; // Velocidad de rotación en grados por segundo
    [SerializeField] float velocidad = 3f;
    public bool movimientoHabilitado = true; // Por defecto, el movimiento está habilitado al inicio

    private Animator animator; // Referencia al componente Animator
    private Rigidbody rb; // Referencia al componente Rigidbody
    private bool estaMoviendo = false; // Variable para controlar si el jugador está moviéndose

    // Método para habilitar el movimiento
    public void HabilitarMovimiento()
    {
        movimientoHabilitado = true;
        Debug.Log("Movimiento habilitado.");
    }

    void Start()
    {
        // Obtener el componente Animator adjunto al GameObject
        animator = GetComponent<Animator>();
        // Obtener el componente Rigidbody adjunto al GameObject
        rb = GetComponent<Rigidbody>();

        // Llamar al método para habilitar el movimiento al iniciar el juego
        HabilitarMovimiento();
    }

    void Update()
    {
        // Verificar si el movimiento está habilitado
        if (movimientoHabilitado)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Verificar si se está presionando alguna tecla de movimiento (W, A, S, D)
            estaMoviendo = (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);

            // Calcular el movimiento en la dirección diagonal para la vista isométrica
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            // Aplicar el movimiento al jugador solo si se está moviendo
            if (estaMoviendo)
            {
                // Mover el jugador utilizando Rigidbody
                Vector3 movement = movementDirection * (speed * Time.deltaTime);
                rb.MovePosition(transform.position + movement);

                // Rotar el jugador hacia la dirección del movimiento
                if (movementDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                // Detener la velocidad del Rigidbody
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    void OnDisable()
    {
        // Cuando el script es desactivado, desactivar todas las animaciones
        if (animator != null)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        // Actualizar el estado de la animación en el Animator
        animator.SetBool("isMoving", estaMoviendo);
    }
}