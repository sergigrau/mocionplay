using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string nomEscenaDesti;
    public Vector3 coordenadasDesti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TPaEscena(0f));
            
            if (!SceneManager.GetSceneByName(nomEscenaDesti).isLoaded)
            {
                SceneManager.LoadScene(nomEscenaDesti, LoadSceneMode.Additive);
            }
        }
    }

    IEnumerator TPaEscena(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        Scene escenaDesti = SceneManager.GetSceneByName(nomEscenaDesti);

        if (escenaDesti.isLoaded)
        {
            Debug.Log("load 2 gg");
            GameObject[] objecteDesti = escenaDesti.GetRootGameObjects();
            foreach (GameObject objecte in objecteDesti)
            {
                if (objecte.CompareTag("Player"))
                {
                    objecte.transform.position = coordenadasDesti;
                    Debug.Log(coordenadasDesti);
                    Debug.Log("load 3 gg");
                    break;
                }
            }
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}