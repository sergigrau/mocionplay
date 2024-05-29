using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPrincipal : MonoBehaviour
{
    public static ManagerPrincipal Instancia;
    public Vector3 PosicioInicial;

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }
}
