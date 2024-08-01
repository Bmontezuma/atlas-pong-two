using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticPortal : MonoBehaviour
{
    public GameObject[] ballPrefabs; // Array of different ball prefabs
    public int numberOfBallsToSpawn = 6; // Number of balls to spawn
    public float spawnRadius = 1f; // Radius within which the balls will spawn around the portal
    public float extraBallSpeed = 2f; // Speed multiplier for the new balls

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Spawn additional balls
            for (int i = 0; i < numberOfBallsToSpawn; i++)
            {
                // Randomize spawn position within a circle
                Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

                // Randomly select a ball prefab from the array
                int randomIndex = Random.Range(0, ballPrefabs.Length);
                GameObject selectedPrefab = ballPrefabs[randomIndex];

                // Instantiate the selected ball prefab
                GameObject newBall = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

                // Give the new balls some initial velocity
                Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Apply random velocity to new balls
                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    rb.velocity = randomDirection * extraBallSpeed;
                }
            }

            // Optional: Destroy the portal after spawning balls or make it inactive
            // Destroy(gameObject);
        }
    }
}
