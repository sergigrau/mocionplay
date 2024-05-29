using System.Collections;
using UnityEngine;

public class MovementJuan : MonoBehaviour
{
    public float velocidadGiro = 60f; // Velocidad de giro en grados por segundo
    public float velocidadAvance = 4f; // Velocidad de avance en unidades por segundo
    public Animator animator; // Referencia al componente Animator

    void Start()
    {
        // Obtener el componente Animator si no se asignó en el Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void IniciarMovimiento()
    {
        // Iniciar el movimiento de giro y avance
        StartCoroutine(GirarYAvanzar());
    }

    IEnumerator GirarYAvanzar()
    {
        if (animator != null)
        {
            animator.Play("JuanCamina");
        }
        else
        {
            Debug.LogWarning("Animator no asignado en MovementJuan. No se puede cambiar la animación.");
        }
        // Calcular el ángulo deseado para girar
        float anguloInicial = transform.eulerAngles.y;
        float anguloDeseado = anguloInicial - 75f; // Girar 75 grados desde la posición actual

        // Girar gradualmente hacia el ángulo deseado
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, anguloDeseado)) > 0.1f)
        {
            float nuevoAngulo = Mathf.MoveTowardsAngle(transform.eulerAngles.y, anguloDeseado, velocidadGiro * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, nuevoAngulo, 0f);
            yield return null;
        }

        // Llamar al estado de animación "JuanCamina" si el Animator está asignado
        

        // Una vez que el ángulo deseado se alcanza, avanzar
        // Calcular la dirección de avance basada en el ángulo girado
        Vector3 direccionAvance = Quaternion.Euler(0f, anguloDeseado, 0f) * Vector3.forward;

        // Calcular la posición final de avance
        Vector3 posicionFinal = transform.position + direccionAvance * 25f;

        // Avanzar gradualmente hacia la posición final
        while (Vector3.Distance(transform.position, posicionFinal) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidadAvance * Time.deltaTime);
            yield return null;
        }

        // Desactivar este script si ya no es necesario
        enabled = false;
    }
}
