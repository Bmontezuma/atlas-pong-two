using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    public TMP_Text player1ScoreText; // Assign your TMP_Text component in the Inspector
    public TMP_Text player2ScoreText; // Assign your TMP_Text component in the Inspector

    private void Start()
    {
        UpdateScoreUI();
    }

    public void Player1Goal()
    {
        player1Score++;
        Debug.Log("Player 1 Score: " + player1Score);
        UpdateScoreUI();
        // Add other game logic for Player 1 scoring a goal here
    }

    public void Player2Goal()
    {
        player2Score++;
        Debug.Log("Player 2 Score: " + player2Score);
        UpdateScoreUI();
        // Add other game logic for Player 2 scoring a goal here
    }

    public void Player1Lose()
    {
        // Add logic for Player 1 losing a point here
    }

    public void Player2Lose()
    {
        // Add logic for Player 2 losing a point here
    }

    private void UpdateScoreUI()
    {
        if (player1ScoreText != null)
        {
            player1ScoreText.text = "Player 1: " + player1Score;
        }
        if (player2ScoreText != null)
        {
            player2ScoreText.text = "Player 2: " + player2Score;
        }
    }
}
