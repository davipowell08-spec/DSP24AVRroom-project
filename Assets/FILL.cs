using UnityEngine;

public class TeacupFill : MonoBehaviour
{
    public float fillAmount = 0f;
    public float fillSpeed = 0.1f;
    public Transform liquidVisual; // A cylinder inside the cup representing the liquid

    void OnParticleCollision(GameObject other)
    {
        if (fillAmount < 1.0f)
        {
            fillAmount += fillSpeed * Time.deltaTime;
            // Scale the "liquid" mesh upward to simulate filling
            liquidVisual.localScale = new Vector3(1, fillAmount, 1);
        }
    }
}