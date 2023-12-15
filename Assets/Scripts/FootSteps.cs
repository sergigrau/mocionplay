using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        audioSource.PlayOneShot(clips[Random.Range(0,clips.Length)]);
    }

}