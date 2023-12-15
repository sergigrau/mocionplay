using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField] public string currentscene;
    [SerializeField] public string objective;
    [SerializeField] public Vector3 exit;
    [SerializeField] public PlayerMotion pl;
    [SerializeField] Fading fade;

    private float curr;
    private bool trans = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            curr = 0.0f;
            trans = true;
            pl.setMove(false);
            fade.show();
        }
        
    }

    public void Update()
    {
        if (trans)
        {
            curr += Time.deltaTime;
            if (curr > 1)
            {
                SceneManager.LoadScene(objective);
                if (exit.magnitude != 0)
                {
                    GameObject.FindWithTag("Player").transform.position = exit;
                }
                SceneManager.UnloadSceneAsync(currentscene);
            }
        }
    }
}







