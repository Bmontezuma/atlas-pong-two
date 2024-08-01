using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BallSpeedColorIndicator : MonoBehaviour
{
    public Rigidbody2D rb; // Rigidbody2D component attached to the ball
    public Renderer ballRenderer; // Renderer component of the ball
    public Color slowColor = Color.blue;
    public Color mediumColor = Color.yellow;
    public Color fastColor = Color.red;
    public float maxSpeed = 20f; // Maximum expected speed

    void Start()
    {
        // Initialize components
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (ballRenderer == null) ballRenderer = GetComponent<Renderer>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing.");
        }

        if (ballRenderer == null)
        {
            Debug.LogError("Renderer component is missing.");
        }
    }

    void Update()
    {
        // Calculate the speed of the ball
        float speed = rb.velocity.magnitude;

        // Log speed for debugging purposes
        Debug.Log($"Speed: {speed}");

        // Determine the percentage of max speed
        float speedPercentage = Mathf.Clamp01(speed / maxSpeed);

        // Log speed percentage for debugging
        Debug.Log($"Speed Percentage: {speedPercentage}");

        // Lerp between colors based on speed percentage
        if (speedPercentage < 0.5f)
        {
            ballRenderer.material.color = Color.Lerp(slowColor, mediumColor, speedPercentage * 2);
        }
        else
        {
            ballRenderer.material.color = Color.Lerp(mediumColor, fastColor, (speedPercentage - 0.5f) * 2);
        }

        // Log current color for debugging
        Debug.Log($"Current Ball Color: {ballRenderer.material.color}");
    }
}


