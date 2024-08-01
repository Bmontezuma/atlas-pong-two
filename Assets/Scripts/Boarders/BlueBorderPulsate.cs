using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBorderPulsate : MonoBehaviour
{
    public Renderer[] borders; // Array of renderers for the borders
    public Color pulseColor = Color.white; // Color to pulse to
    public float pulseDuration = 1f; // Duration for one pulse cycle
    public float pulseIntensity = 1.5f; // Intensity of the pulse

    private Color originalColor;
    private bool isPulsating = false;

    void Start()
    {
        if (borders.Length > 0)
        {
            originalColor = borders[0].material.color;
        }
    }

    public void StartPulsating()
    {
        if (!isPulsating)
        {
            isPulsating = true;
            StartCoroutine(PulsateBorders());
        }
    }

    public void StopPulsating()
    {
        isPulsating = false;
        // Reset to original color
        foreach (Renderer border in borders)
        {
            border.material.color = originalColor;
        }
    }

    private IEnumerator PulsateBorders()
    {
        float time = 0f;

        while (isPulsating)
        {
            time += Time.deltaTime;
            float lerp = Mathf.PingPong(time / pulseDuration, 1f);
            Color currentColor = Color.Lerp(originalColor, pulseColor * pulseIntensity, lerp);

            foreach (Renderer border in borders)
            {
                border.material.color = currentColor;
            }

            yield return null;
        }
    }
}
