using UnityEngine;

public class LiquidPour : MonoBehaviour
{
    [Header("Settings")]
    public ParticleSystem liquidParticles;
    public float pourThreshold = 45f; // Angle at which pouring starts

    [Header("Stream Control")]
    private bool isPouring = false;

    void Update()
    {
        // Calculate the tilt angle relative to the "Up" direction
        // We check if the angle between the bottle's 'Up' and the World 'Up'
        // is greater than our threshold.
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);

        if (tiltAngle > pourThreshold)
        {
            StartPouring();
        }
        else
        {
            StopPouring();
        }
    }

    void StartPouring()
    {
        if (isPouring) return;

        isPouring = true;
        liquidParticles.Play();
    }

    void StopPouring()
    {
        if (!isPouring) return;

        isPouring = false;
        liquidParticles.Stop();
    }
}
