using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private string objective;
    [SerializeField] private Vector3 exit;
    [SerializeField] private PlayerMotion pl;
    [SerializeField] private Fading fade;
    [SerializeField] private AudioClip doorOpeningSound;
    
    private float curr;
    private bool trans = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trans = true;
            pl.setMove(false);
            if (fade != null) fade.show();
        }
    }
    
    private void PlayDoorOpeningSound()
    {
        // AudioSource associat amb l'objecte 
        AudioSource audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        
        // Reproduir el so
        audioSource.PlayOneShot(doorOpeningSound, 0.7F);
    }

    private void Update()
    {
        if (trans)
        {
            curr += Time.deltaTime;
            if (curr > 1)
            {
                var scene = SceneManager.LoadSceneAsync(objective);
                scene.completed += (operation =>
                {
                    GameObject.FindWithTag("Player").transform.position = exit;
                    PlayDoorOpeningSound(); // Reproduir so
                });
                trans = false;
            }
        }
    }
}