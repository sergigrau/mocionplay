using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionEscenarios : MonoBehaviour
{

    [SerializeField] public string currentscene;
    [SerializeField] public string targetScene;
    //[SerializeField] public Vector3 exit;
    [SerializeField] public PlayerMotion player;
    [SerializeField] Fading fade;

    private float currentTime;
    private bool transition = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            currentTime = 0.0f;
            transition = true;
            player.setMove(false);
            fade.show();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionChange = new Vector3(100000000000000000, 0, 0); 
        Cargar(targetScene, positionChange);
    }

    public void Cargar(string nombreEscenario, Vector3 position)
    {
        if (transition)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 1)
            {
                SceneManager.LoadScene(nombreEscenario);
                Debug.Log(position);
                GameObject.FindWithTag("Player").transform.position = position;
                SceneManager.UnloadSceneAsync(currentscene);
            }
        }
    }


    public void ComprobarArea(Vector3 posicion, float distancia)
    {

    }

}
