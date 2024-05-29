using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneTrigger : MonoBehaviour
{
    public void Start()
    {
        print("Comienza");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name)
        {
            case "Porta":
                SceneManager.LoadScene("Scene1");
                break;
            case "X":
                SceneManager.LoadScene("Super2");
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
