using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    //public Canvas canvas5;

    public void ActivateCanvasOnClick()
    {
        Debug.LogWarning("FFFFFFFFFFFF");

        // Activa el primer canvas si existe
        if (canvas1 != null)
        {
            canvas1.enabled = true;
        }

        // Desactiva los otros canvas si existen
        if (canvas2 != null)
        {
            canvas2.enabled = false;
        }
        
        if (canvas3 != null)
        {
            canvas3.enabled = false;
        }

        if (canvas4 != null)
        {
            canvas4.enabled = false;
        }

        
    }
}