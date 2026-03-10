using UnityEngine;

public class ConstantPour : MonoBehaviour
{
    public ParticleSystem liquidParticles;

    void Start()
    {
        // Ensure the particle system starts playing immediately
        if (liquidParticles != null)
        {
            // Optional: Ensure "Play on Awake" is handled via code
            var main = liquidParticles.main;
            main.playOnAwake = true;

            liquidParticles.Play();
        }
        else
        {
            Debug.LogError("Assign a Particle System to the ConstantPour script!");
        }
    }

    // Update is empty because we no longer care about the angle!
}