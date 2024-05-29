using UnityEngine;

public class PlayParticlesOnTouch : MonoBehaviour
{
    public ParticleSystem particleSystem; // Referencia al sistema de part�culas

    void OnMouseDown()
    {
        if (particleSystem != null)
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
            else
            {
                particleSystem.Play();
            }
        }
    }
}
