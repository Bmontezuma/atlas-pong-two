using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed = 5f;
    public float extraSpeed = 1f;
    public float maxExtraSpeed = 10f;
    public GameObject impactEffectPrefab; // Reference to the particle effect prefab
    public Renderer ballRenderer;

    public Color slowColor = Color.blue;    // Define the slow color
    public Color mediumColor = Color.yellow; // Define the medium color
    public Color fastColor = Color.red;     // Define the fast color

    private int hitCounter = 0;
    private Rigidbody2D rb;
    private CameraShake cameraShake;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraShake = Camera.main.GetComponent<CameraShake>();

        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        MoveBall(new Vector2(-1, 0)); // Initial direction
    }

    public void MoveBall(Vector2 direction)
    {
        // Normalize the direction vector to ensure consistent movement
        direction = direction.normalized;

        // Calculate the ball's speed based on the hit counter
        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        // Clamp the ball's speed to prevent it from exceeding maxExtraSpeed
        ballSpeed = Mathf.Clamp(ballSpeed, 0, maxExtraSpeed);

        // Apply the calculated velocity to the ball's Rigidbody2D component
        rb.velocity = direction * ballSpeed;

        // Update the ball's color based on its speed
        UpdateBallColor(ballSpeed);

        // Log hit counter and ball speed for debugging purposes
        Debug.Log($"Hit Counter: {hitCounter}, Ball Speed: {ballSpeed}");
    }

    public void IncreaseHitCounter()
    {
        // Increment the hit counter if the speed hasn't reached the maximum limit
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
            Debug.Log($"Hit Counter Increased: {hitCounter}");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            // Trigger camera shake
            cameraShake.TriggerShake();

            // Instantiate the impact effect at the collision point
            GameObject impactEffect = Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);

            // Destroy the impact effect after the particles have finished
            Destroy(impactEffect, 0.5f); // Adjust the time to match your particle lifetime

            // Increase the hit counter for speed increment
            IncreaseHitCounter();
        }
    }

    private void UpdateBallColor(float speed)
    {
        // Calculate the lerp factor based on the speed
        float lerpFactor = Mathf.Clamp(speed / maxExtraSpeed, 0f, 1f);

        // Define the color change thresholds
        if (lerpFactor < 0.5f)
        {
            ballRenderer.material.color = Color.Lerp(slowColor, mediumColor, lerpFactor * 2);
        }
        else
        {
            ballRenderer.material.color = Color.Lerp(mediumColor, fastColor, (lerpFactor - 0.5f) * 2);
        }
    }
}
