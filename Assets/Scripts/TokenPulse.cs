using UnityEngine;

// Animates tokens with a pulsing emission glow and continuous rotation
public class TokenPulse : MonoBehaviour
{
    public Color emissionColor = Color.green;
    public float pulseSpeed = 2f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Oscillate emission intensity using a sine wave for a pulsing glow effect
        float intensity = Mathf.Lerp(minIntensity, maxIntensity,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        mat.SetColor("_EmissionColor", emissionColor * intensity);

        // Spin the token on two axes
        transform.Rotate(0f, 45f * Time.deltaTime, 45f * Time.deltaTime);
    }
}