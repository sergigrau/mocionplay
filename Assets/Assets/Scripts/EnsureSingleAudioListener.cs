using UnityEngine;

public class EnsureSingleAudioListener : MonoBehaviour
{
    void Awake()
    {
        // Find all Audio Listeners in the scene
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // If there is more than one Audio Listener, remove all but the first one
        if (audioListeners.Length > 1)
        {
            for (int i = 1; i < audioListeners.Length; i++)
            {
                Destroy(audioListeners[i]);
            }
        }
    }
}