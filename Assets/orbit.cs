using UnityEngine;

public class Orbit : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;        // The object to orbit around
    public float orbitSpeed = 50.0f; // Degrees per second
    public float distance = 10.0f;   // Distance from the target

    [Header("Options")]
    public Vector3 orbitAxis = Vector3.up; // The axis of rotation (Up = Horizontal orbit)
    public bool lookAtTarget = true;       // Should the object always face the center?

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Orbit script: No target assigned!");
            return;
        }

        // Initialize position at the desired distance
        Vector3 relativePosition = (transform.position - target.position).normalized * distance;
        transform.position = target.position + relativePosition;
    }

    void Update()
    {
        if (target != null)
        {
            // 1. Rotate the position around the target's center
            transform.RotateAround(target.position, orbitAxis, orbitSpeed * Time.deltaTime);

            // 2. Optional: Keep the object facing the target
            if (lookAtTarget)
            {
                transform.LookAt(target);
            }

            // 3. Optional: Fix distance if it drifts (useful for physics interactions)
            Vector3 desiredPosition = (transform.position - target.position).normalized * distance + target.position;
            transform.position = desiredPosition;
        }
    }
}