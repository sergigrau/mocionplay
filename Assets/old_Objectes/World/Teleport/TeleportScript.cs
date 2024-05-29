using System;
using System.Collections;
using System.Collections.Generic;
using lib;
using Personajes.Carlos;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TeleportScript : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private String destinationScene;
    [SerializeField] private Fases fases = new Fases();
    private int fase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        fase = PlayerPrefs.GetInt("fase");
        if (!fases.getState(fase)) return;
        if (other.CompareTag("Player"))
        {
            if (destination != null)
            {
                Vector3 pos = destination.transform.position;
                other.transform.position = new Vector3(pos.x, 0, pos.z);
            }
            if (destinationScene != null)
            {
                string prevScene = SceneManager.GetActiveScene().name;
                var scene = SceneManager.LoadSceneAsync(destinationScene);
                scene.completed += (x) =>
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentCarlos>().sceneName = prevScene;
                };
            }
        }
    }
}
