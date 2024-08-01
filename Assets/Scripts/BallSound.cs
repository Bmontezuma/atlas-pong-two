using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip player1HitSound1;
    public AudioClip player2HitSound1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            PlaySound(player1HitSound1);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            PlaySound(player2HitSound1);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("AudioClip or AudioSource is null! Cannot play sound.");
        }
    }
}
