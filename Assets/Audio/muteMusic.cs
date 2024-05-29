using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    private bool musicMuted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKey(KeyCode.LeftControl))
        {
            ToggleMute();
        }
    }

    void ToggleMute()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.mute = !audioSource.mute;
        musicMuted = audioSource.mute;
        Debug.Log("Música " + (musicMuted ? "silenciada" : "activada"));
    }
}
