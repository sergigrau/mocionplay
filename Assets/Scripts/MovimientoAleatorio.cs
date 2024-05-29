using UnityEngine;

public class MovimientoAleatorio : MonoBehaviour
{
    public float velocidadMaxima = 1.0f;
    public float cambioDireccionIntervaloMin = 2.0f;
    public float cambioDireccionIntervaloMax = 5.0f;
    public float quietoIntervaloMin = 3.0f;
    public float quietoIntervaloMax = 8.0f;
    public float maxAnguloGiro = 90.0f;

    private Vector3 direccionActual;
    private float tiempoUltimoCambioDireccion;
    private bool enMovimiento = true;
    private Quaternion rotacionHorizontal;
    private Quaternion rotacionVertical;

    void Start()
    {
       
        rotacionHorizontal = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        rotacionVertical = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);

        
        direccionActual = ObtenerNuevaDireccion();
        tiempoUltimoCambioDireccion = Time.time;
    }

    void Update()
    {
        if (enMovimiento)
        {
            
            float tiempoTranscurridoCambioDireccion = Time.time - tiempoUltimoCambioDireccion;

            
            if (tiempoTranscurridoCambioDireccion > Random.Range(cambioDireccionIntervaloMin, cambioDireccionIntervaloMax))
            {
                direccionActual = ObtenerNuevaDireccion();
                tiempoUltimoCambioDireccion = Time.time;
            }

           
            float velocidad = Random.Range(0, velocidadMaxima);

            transform.Translate(direccionActual * velocidad * Time.deltaTime, Space.World);

            Quaternion nuevaRotacion = Quaternion.LookRotation(direccionActual);
            nuevaRotacion *= rotacionHorizontal; 
            nuevaRotacion *= rotacionVertical; 
            transform.rotation = Quaternion.Slerp(transform.rotation, nuevaRotacion, Time.deltaTime);
        }
    }

    
    private Vector3 ObtenerNuevaDireccion()
    {
        
        Vector2 direccionAleatoria2D = Random.insideUnitCircle.normalized;
        Vector3 direccionAleatoria = new Vector3(direccionAleatoria2D.x, 0f, Mathf.Abs(direccionAleatoria2D.y));
        return direccionAleatoria;
    }
}