
using System;
using UnityEngine;

//
// Quadra Pong 1974 v2019.02.28
//
// v2021.04.13
//

public class ScoreController : MonoBehaviour
{
    public static ScoreController scoreController;

    public Transform[] player1Score;
    public Transform[] player2Score;
    public Transform[] player3Score;
    public Transform[] player4Score;

    public const int PLAYER_1 = 1;
    public const int PLAYER_2 = 2;
    public const int PLAYER_3 = 3;
    public const int PLAYER_4 = 4;


    private void Awake()
    {
        scoreController = this;
    }


    public void InitialiseScores()
    {
        for (int scoreDigit = 0; scoreDigit < player1Score.Length; scoreDigit++)
        {
            player1Score[scoreDigit].gameObject.SetActive(true);
            player2Score[scoreDigit].gameObject.SetActive(true);
            player3Score[scoreDigit].gameObject.SetActive(true);
            player4Score[scoreDigit].gameObject.SetActive(true);
        }
    }


    public void UpdateScoreDisplay(int score, int display)
    {
        switch (display)
        {
            case PLAYER_1:

                UpdatePlayer1(score);

                break;

            case PLAYER_2:

                UpdatePlayer2(score);

                break;

            case PLAYER_3:

                UpdatePlayer3(score);

                break;

            case PLAYER_4:

                UpdatePlayer4(score);

                break;
        }
    }


    private void UpdatePlayer1(int score)
    {
        player1Score[score].gameObject.SetActive(false);
    }


    private void UpdatePlayer2(int score)
    {
        player2Score[score].gameObject.SetActive(false);
    }


    private void UpdatePlayer3(int score)
    {
        player3Score[score].gameObject.SetActive(false);
    }


    private void UpdatePlayer4(int score)
    {
        player4Score[score].gameObject.SetActive(false);
    }


} // end of class
