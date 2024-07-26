using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    public GameObject impactEffectPrefab; // Reference to the particle effect prefab

    private int hitCounter = 0;
    private Rigidbody2D rb;
    private CameraShake cameraShake;

    // Start is called before the first frame update
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

        MoveBall(new Vector2(-1, 0));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
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
}
