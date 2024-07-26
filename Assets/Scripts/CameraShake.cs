using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.1f; // Duration of the shake
    public float shakeMagnitude = 0.1f; // Magnitude of the shake

    private Vector3 originalPosition;
    private float shakeTimeRemaining;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimeRemaining -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    public void TriggerShake()
    {
        shakeTimeRemaining = shakeDuration;
    }
}
