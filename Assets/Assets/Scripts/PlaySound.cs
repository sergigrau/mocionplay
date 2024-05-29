using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    private int loopCount = 0;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        // Set the loop property to true
        audioSource.loop = true;
    }

    public void PlaySoundEffect()
    {
        // Play the sound effect
        audioSource.Play();
        // Start the coroutine to stop the sound after it has looped 5 times
        StartCoroutine(StopSoundAfterFiveLoops());
    }

    IEnumerator StopSoundAfterFiveLoops()
    {
        while (loopCount < 5)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            loopCount++;
        }
        // Stop the sound
        audioSource.Stop();
    }
}