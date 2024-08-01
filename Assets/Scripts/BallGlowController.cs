using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGlowController : MonoBehaviour
{
    private Material ballMaterial;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        ballMaterial = renderer.material;

        // Set initial glow color and intensity
        SetGlowColor(new Color(0.027f, 0f, 1f), 2.0f); // Using normalized color values for #0700FF
    }

    public void SetGlowColor(Color color, float intensity)
    {
        ballMaterial.SetColor("_EmissionColor", color * intensity);
        DynamicGI.SetEmissive(GetComponent<Renderer>(), color * intensity);
    }
}
