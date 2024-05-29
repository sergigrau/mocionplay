using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en este GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            audioSource.UnPause();
            isPaused = false;
        }
        else
        {
            audioSource.Pause();
            isPaused = true;
        }
    }
}
