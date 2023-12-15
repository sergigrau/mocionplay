using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private static Vector3 worldPos;
    // Start is called before the first frame update
    void Start()
    {
        worldPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                
                if (other.gameObject.CompareTag("Uni"))
                {
                    SceneManager.LoadScene(3);
                }
                else if (other.gameObject.CompareTag("CasaSamuel"))
                {
                    //worldPos = other.gameObject.transform.position;
                    SceneManager.LoadScene(2);
                }

            } else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1);
            }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }



}
