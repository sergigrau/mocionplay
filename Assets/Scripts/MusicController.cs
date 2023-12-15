using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource music;

    public Sprite btImage1;
    public Sprite btImage2;

    public Button bt;

    static bool isPlaying = true;

    public void ControllerMusic()
    {

        if (isPlaying)
        {
            isPlaying = false;
            this.StopMusic();
        }
        else
        {
            isPlaying=true;
            this.PlayMusic();
        }
    }


    public void PlayMusic()
    {
        music.Play();
        bt.GetComponent<Image>().sprite = btImage1;
    }

    public void StopMusic()
    {
        music.Stop();
        bt.GetComponent<Image>().sprite = btImage2;

    }
}
