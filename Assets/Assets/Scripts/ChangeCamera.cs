using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera nuevaCamara; // Referencia a la nueva cámara que se activará
    public Transform character1; // Referencia al Transform del personaje 1
    public Transform character2; // Referencia al Transform del personaje 2
    public string animationNameCharacter1; // Nombre de la animación del personaje 1
    public string animationNameCharacter2; // Nombre de la animación del personaje 2
    public Canvas canvas1; // Referencia al primer canvas

private void OnTriggerEnter(Collider other)
{
    // Verificar si el objeto que colisiona es el personaje 1
    if (other.CompareTag("Player"))
    {   
        Animator animatorCharacter1 = character1.GetComponent<Animator>();
        Animator animatorCharacter2 = character2.GetComponent<Animator>();
        // Desactivar scripts de movimiento o control
        DisableMovement(character1);

        // Cambiar a la nueva cámara
        nuevaCamara.enabled = true;

        // Desactivar la cámara actual
        Camera.main.enabled = false;

        // Ejecutar la animación en ambos personajes
        if (character1 != null && character2 != null)
        {
            // Obtener el componente Animator de los personajes
            

            // Detener las animaciones anteriores
            if (animatorCharacter1 != null)
            {
                animatorCharacter1.StopPlayback();
            }
            if (animatorCharacter2 != null)
            {
                animatorCharacter2.StopPlayback();
            }

            // Ejecutar la animación en ambos personajes
            if (animatorCharacter1 != null && animatorCharacter2 != null)
            {
                // Activa la animación "Hablar" utilizando un parámetro de disparo
                animatorCharacter1.Play("CarlosParla");
                

                animatorCharacter2.Play(animationNameCharacter2);
                Debug.Log("GAy");

                // Calcular la dirección entre los dos personajes
                Vector3 direction = character2.position - character1.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                // Rotar ambos personajes para que se miren mutuamente
                character1.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
                character2.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y + 180f, 0f);
            }
        }

        // Desactivar canvas
        if (canvas1 != null)
        {
            canvas1.enabled = false;
        }
    }
}

    private void DisableMovement(Transform character)
    {
        // Desactivar scripts de movimiento o control
        MovimientoLibre movementScript = character.GetComponent<MovimientoLibre>();
        if (movementScript != null)
        {
            // Deshabilitar el movimiento
            movementScript.movimientoHabilitado = false;
            
            // Congelar la rotación del Rigidbody para evitar que el personaje se caiga hacia atrás
            Rigidbody rb = character.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            
            Debug.Log("DESACTIVADOO");
        }
    }
    private void StopMovimentLliureScript()
    {
        // Find the GameObject with the script named "MovimentLliure" and stop it
        GameObject movimentLliureObject = GameObject.Find("MovimientoLibre");
        if (movimentLliureObject != null)
        {
            MovimientoLibre movimentLliureScript = movimentLliureObject.GetComponent<MovimientoLibre>();
            if (movimentLliureScript != null)
            {
                movimentLliureScript.enabled = false;
            }
        }
    }
    private void StopAnimatorAnimations(string animatorName)
    {
        // Buscar el GameObject con el Animator con el nombre especificado
        GameObject[] objectsWithAnimator = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in objectsWithAnimator)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null && obj.name == animatorName)
            {
                animator.StopPlayback(); // Detiene todas las animaciones en el Animator
                return; // Detenemos el bucle después de encontrar y detener el Animator deseado
            }
        }
    }


// Llamada a la función para detener las animaciones del Animator con nombre "Hola1"
    

}
    