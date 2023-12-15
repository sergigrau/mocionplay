using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAction : MonoBehaviour
{
    [SerializeField] public CanvasGroup cv;
    [SerializeField] public Button button;
    [SerializeField] private PlayerInteraction pl;

    public void triggerScene()
    {
        pl.displayAction();
        if (pl.sca.glasses.isActive())
        {
            pl.sca.glasses.switchActive();
        }
    }


}
