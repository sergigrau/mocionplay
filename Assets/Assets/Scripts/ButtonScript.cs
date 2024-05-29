using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Camera nuevaCamara; // Referencia a la nueva cámara que se activará
    public Camera camaraPrincipal; // Referencia a la cámara principal
    public string movimientoLibreCharacterTag = "Player"; // Tag del personaje en el que se ejecutará el script MovimientoLibre
    public string movementJuanCharacterTag = "Caracther2"; // Tag del personaje en el que se ejecutará el script MovementJuan
    public GameObject objetoADesactivar; // Referencia al GameObject que se desactivará
    

    public void OnButtonClick()
    {
        objetoADesactivar.SetActive(false);

        // Buscar el personaje con el tag para el script MovimientoLibre
        GameObject characterMovimientoLibre = GameObject.FindGameObjectWithTag(movimientoLibreCharacterTag);
        Animator animatorCharacter1 = characterMovimientoLibre.GetComponent<Animator>();
        animatorCharacter1.Play("Caminar Carlos");
        
        // Verificar si se encontró un personaje para el script MovimientoLibre
        if (characterMovimientoLibre != null)
        {
            // Obtener el componente MovimientoLibre del personaje
            MovimientoLibre movimientoLibreScript = characterMovimientoLibre.GetComponent<MovimientoLibre>();
            
            // Verificar si se encontró el script MovimientoLibre
            if (movimientoLibreScript != null)
            {
                // Llamar al método para habilitar el movimiento en el personaje
                movimientoLibreScript.HabilitarMovimiento();
            }
            else
            {
                Debug.LogWarning("MovimientoLibre script not found on character with tag '" + movimientoLibreCharacterTag + "'.");
            }
        }
        else
        {
            Debug.LogWarning("Character with tag '" + movimientoLibreCharacterTag + "' not found.");
        }

        // Buscar el personaje con el tag para el script MovementJuan
        GameObject characterMovementJuan = GameObject.FindGameObjectWithTag(movementJuanCharacterTag);
        
        // Verificar si se encontró un personaje para el script MovementJuan
        if (characterMovementJuan != null)
        {
            // Ejecutar el script MovementJuan en el personaje
            MovementJuan movementJuanScript = characterMovementJuan.GetComponent<MovementJuan>();
            if (movementJuanScript != null)
            {
                movementJuanScript.IniciarMovimiento();
            }
            else
            {
                Debug.LogWarning("MovementJuan script not found on character with tag '" + movementJuanCharacterTag + "'.");
            }
        }
        else
        {
            Debug.LogWarning("Character with tag '" + movementJuanCharacterTag + "' not found.");
        }

        // Cambiar a la nueva cámara y desactivar la cámara principal
        nuevaCamara.enabled = true;
        camaraPrincipal.enabled = false;
    }
}
