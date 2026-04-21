using UnityEngine;

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
        float intensity = Mathf.Lerp(minIntensity, maxIntensity,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        mat.SetColor("_EmissionColor", emissionColor * intensity);

        transform.Rotate(0f, 45f * Time.deltaTime, 45f * Time.deltaTime);
    }
}