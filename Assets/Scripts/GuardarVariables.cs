using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarVariables : MonoBehaviour
{
    [Header("0: bien - 1 : tarde")]

    public int llegarTarde;

    public void Start()
    {
        SetInt("llegaTarde",llegarTarde);
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value); // Use the provided Value parameter
    }

}
