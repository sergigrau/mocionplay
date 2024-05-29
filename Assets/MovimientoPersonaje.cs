using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

/**
* Classe que implementa el moviment lliure d'un objecte
* i la instàciació'objectes
* 1.0 8.04.2015
*/
public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadCaminar = 2f;
    public float velocidadGiro = 10f;

    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direccion = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        // Mover y rotar el personaje
        if (direccion.magnitude >= 0.1f)
        {
            float angulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg;
            float nuevoAngulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadGiro, 0.1f);

            transform.rotation = Quaternion.Euler(0f, nuevoAngulo, 0f);

            Vector3 movimiento = direccion * velocidadCaminar * Time.deltaTime;
            transform.Translate(movimiento, Space.World);
        }
    }
}