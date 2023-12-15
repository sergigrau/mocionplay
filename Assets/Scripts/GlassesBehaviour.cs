using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GlassesBehaviour : MonoBehaviour
{
    private bool active = false;
    
    [SerializeField] private WatchBehaviour watch;
    [SerializeField] public Button bt;
    [SerializeField] public CanvasGroup cv;
    [SerializeField] public Fading fade;


    public bool isActive()
    {
        return active;
    }

    public void switchActive()
    {
        if (!active)
        {
            watch.timeMultiplier = 20;
            fade.show();
        }
        else
        {
            watch.timeMultiplier = 1;
            fade.hide();
        }
        active = !active;
    }
    
}
