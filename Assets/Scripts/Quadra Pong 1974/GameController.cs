
using System.Collections;
using UnityEngine;

//
// Quadra Pong Atari 1974 v2019.02.28
//
// v2023.12.29
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    // game arena boundaries
    public const float UPPER_BOUNDARY = 6.25f;
    public const float LOWER_BOUNDARY = -6.25f;
    public const float LEFT_BOUNDARY = -6.25f;
    public const float RIGHT_BOUNDARY = 6.25f;
  
    public const float CENTRE_COURT = 0f;
   
    //private const float START_DELAY = 1f;
    private const float RESTART_DELAY = 5f;

    // direction of paddle
    public const int STOPPED = 0;

    public const int UP = 1;

    public const int DOWN = -1;

    public const int LEFT = -1;

    public const int RIGHT = 1;

    // reference to text components
    //public Text insertCoinsText;
    //public Text coinsInsertedText;

    //public Text gameOverText;
    //public Text pressStartText;

    // variables for player's scores
    public int player1Score;

    public int player2Score;

    public int player3Score;

    public int player4Score;

    // game credits
    public int gameCredits;

    // player difficulty settings
    //private float leftDifficultyASpriteWidth;
    //private float leftDifficultyASpriteHeight;

    //private float leftDifficultyBSpriteWidth;
    //private float leftDifficultyBSpriteHeight;

    //private float rightDifficultyASpriteWidth;
    //private float rightDifficultyASpriteHeight;

    //private float rightDifficultyBSpriteWidth;
    //private float rightDifficultyBSpriteHeight;

    // game mode
    [HideInInspector] public bool canPlay;
    //[HideInInspector] public bool inPlayMode;
    [HideInInspector] public bool inAttractMode;
    //[HideInInspector] public bool inPawzMode;

    [HideInInspector] public bool gameOver;

    [HideInInspector] public bool twoPlayer;


    // paddle sizes
    //private const float DIFFICULTY_A_WIDTH = 0.4f;
    //private const float DIFFICULTY_A_HEIGHT = 0.6f;
    //private const float DIFFICULTY_B_WIDTH = 0.4f;
    //private const float DIFFICULTY_B_HEIGHT = 0.4f;


    public const int PLAYER_ONE = 1;
    public const int PLAYER_TWO = 2;
    public const int PLAYER_THREE = 3;
    public const int PLAYER_FOUR = 4;


    // colours
    public const int WHITE = 255;
    public const int RED = 255;
    public const int GREEN = 255;
    public const int BLUE = 255;


    //public const int WINNING_SCORE = 0;
    public const int START_SCORE = 4;
    private const int GAMEOVER_SCORE = 0;


    public const int INSERT_COINS = 0;
    public const int ONE_PLAYER_COINS = 1;
    public const int MAXIMUM_COINS = 99;


    // console initialisation
    //private const string GAME_TITLE = "QUADRA PONG";
    //private const int TV_MODE = AtariConsoleController.BW_TV;



    private void Awake()
    {
        gameController = this;
    }


    void Start()
    {
        Startup();
    }


    private void Update()
    {
        KeyboardController();
    }


    private void Startup()
    {
        canPlay = false;

        gameOver = true;

        inAttractMode = true;

        SetAttractModeState(inAttractMode);

        ResetPlayerScore();

        StartAttractMode();
    }


    private void SetAttractModeState(bool gameObjectIsActive)
    {
        BallController.ballController.ballTransform.gameObject.SetActive(!gameObjectIsActive);

        Player1Controller.player1.paddleTransform.gameObject.SetActive(!gameObjectIsActive);
        
        Player2Controller.player2.paddleTransform.gameObject.SetActive(!gameObjectIsActive);

        Player3Controller.player3.paddleTransform.gameObject.SetActive(!gameObjectIsActive);

        Player4Controller.player4.paddleTransform.gameObject.SetActive(!gameObjectIsActive);

        Player1Controller.player1.goalTransform.gameObject.SetActive(gameObjectIsActive);

        Player2Controller.player2.goalTransform.gameObject.SetActive(gameObjectIsActive);

        Player3Controller.player3.goalTransform.gameObject.SetActive(gameObjectIsActive);

        Player4Controller.player4.goalTransform.gameObject.SetActive(gameObjectIsActive);
    }


    private void ResetPlayerScore()
    {
        player1Score = START_SCORE;

        player2Score = START_SCORE;

        player3Score = START_SCORE;

        player4Score = START_SCORE;

        ScoreController.scoreController.InitialiseScores();
    }


    public void StartAttractMode()
    {
        //gameOverText.gameObject.SetActive(true);

        //inAttractMode = true;
        //inPlayMode = false;

        //AtariConsoleController.atariConsoleController.SetPawzModeSwitches();

        // show atari console
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);

        // check if there are any credits
        //if (gameCredits == INSERT_COINS)
        //{
        //insertCoinsText.gameObject.SetActive(true);
        //}

        //AtariConsoleController.atariConsoleController.SetGameSelection();

        //Player1Controller.player1.player1IsComputer = true;

        //Player2Controller.player2.player2IsComputer = true;

        //Player3Controller.player3.player3IsComputer = true;

        //Player4Controller.player4.player4IsComputer = true;

        //player2Controller.isPlayer2 = false;

        // initialise paddles
        //Player1Controller.player1.Initialise();

        //Player2Controller.player2.Initialise();

        //Player3Controller.player3.Initialise();

        //Player4Controller.player4.Initialise();

        // call ball controller script
        BallController.ballController.Initialise();
    }


    private void KeyboardController()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartOnePlayer();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartTwoPlayer();
            }
        }
    }


    private void StartOnePlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = true;

        Player3Controller.player3.player3IsComputer = true;

        Player4Controller.player4.player4IsComputer = true;

        twoPlayer = false;

        Initialise();
    }


    private void StartTwoPlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = false;

        Player3Controller.player3.player3IsComputer = true;

        Player4Controller.player4.player4IsComputer = true;

        twoPlayer = true;

        Initialise();
    }


    private void Initialise()
    {
        inAttractMode = false;

        ResetPlayerScore();

        SetAttractModeState(inAttractMode);

        Player1Controller.player1.Initialise();

        if (twoPlayer || Player2Controller.player2.player2IsComputer)
        {
            Player2Controller.player2.Initialise();
        }

        Player3Controller.player3.Initialise();

        Player4Controller.player4.Initialise();

        ReadyPlayerOne();
    }


    private void ReadyPlayerOne()
    {
        //yield return new WaitForSeconds(startDelay);

        gameOver = false;

        canPlay = true;

        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }

























    private void SetAtariConsoleMode(int consoleMode)
    {
        //AtariConsoleController.atariConsoleController.consoleMode = consoleMode;

        //AtariConsoleController.atariConsoleController.SetConsoleMode(consoleMode);
    }


    private void InitialiseGameModes()
    {
        gameCredits = INSERT_COINS;

        //UpdateGameCreditsText();

        canPlay = false;

        //inPawzMode = false;
        inAttractMode = false;
        //inPlayMode = false;
    }


    private void InitialiseConsoleSystem()
    {
        //AtariConsoleController.atariConsoleController.initialisingConsoleSystem = true;

        //AtariConsoleController.atariConsoleController.InitialiseConsole(GAME_TITLE, TV_MODE);
    }


    public void InitialiseDifficultySwitchSettings()
    {
        //leftDifficultyASpriteHeight = DIFFICULTY_A_HEIGHT;

        //leftDifficultyASpriteWidth = DIFFICULTY_A_WIDTH;

        //leftDifficultyBSpriteHeight = DIFFICULTY_B_HEIGHT;

        //leftDifficultyBSpriteWidth = DIFFICULTY_B_WIDTH;

        //rightDifficultyASpriteHeight = DIFFICULTY_A_HEIGHT;

        //rightDifficultyASpriteWidth = DIFFICULTY_A_WIDTH;

        //rightDifficultyBSpriteHeight = DIFFICULTY_B_HEIGHT;

        //rightDifficultyBSpriteWidth = DIFFICULTY_B_WIDTH;
    }



    public void SetClassicMode(int tvMode)
    {
        SetBallColour(tvMode, PLAYER_ONE);
    }


    public void SetColourMode(int tvMode)
    {
        SetBallColour(tvMode, PLAYER_ONE);
    }


    public void SetLeftDifficultyA()
    {
        //player1Controller.gameObject.transform.localScale = new Vector3(leftDifficultyASpriteWidth, leftDifficultyASpriteHeight, 0);
    }


    public void SetLeftDifficultyB()
    {
        //player1Controller.gameObject.transform.localScale = new Vector3(leftDifficultyBSpriteWidth, leftDifficultyBSpriteHeight, 0);
    }


    public void SetRightDifficultyA()
    {
        //player2Controller.gameObject.transform.localScale = new Vector3(rightDifficultyASpriteWidth, rightDifficultyASpriteHeight, 0);
    }


    public void SetRightDifficultyB()
    {
        //player2Controller.gameObject.transform.localScale = new Vector3(rightDifficultyBSpriteWidth, rightDifficultyBSpriteHeight, 0);
    }


    public void SetPawzMode()
    {
        //SetGamePadControllers();

        //ballController.FreezeBall();

        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);
    }


    public void SetPlayMode()
    {
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

        //SetGamePadControllers();

        //ballController.ResumeBall();
    }


    public void SetBallColour(int tvMode, int player)
    {/*
        if (tvMode == AtariConsoleController.COLOUR_TV && !inDemoMode)
        {
            switch (player)
            {
                case PLAYER_ONE:

                    // red
                    ballController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(RED, 0, 0);

                    break;

                case PLAYER_TWO:

                    // green
                    ballController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(0, GREEN, 0);

                    break;

                case PLAYER_THREE:

                    // blue
                    ballController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, BLUE);

                    break;

                case PLAYER_FOUR:

                    // yellow
                    ballController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(RED, GREEN, 0);

                    break;
            }
        }

        else
        {
            // white
            ballController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(WHITE, WHITE, WHITE);
        }*/
    }


    // start one player game
    public void StartOnePlayerGame()
    {
        //player1Controller.player1IsComputer = false;


        //player2Controller.player2IsComputer = true;

        //player2Controller.isPlayer2 = false;


        //player3Controller.player3IsComputer = true;

        //player3Controller.isPlayer3 = false;


        //player4Controller.player4IsComputer = true;

        //player4Controller.isPlayer4 = false;


        InitialiseGameMode();
    }


    // start two player game
    public void StartTwoPlayerGame()
    {
        //player1Controller.player1IsComputer = false;


        //player2Controller.player2IsComputer = false;

        //player2Controller.isPlayer2 = true;


        //player3Controller.player3IsComputer = true;

        //player3Controller.isPlayer3 = false;


        //player4Controller.player4IsComputer = true;

        //player4Controller.isPlayer4 = false;


        InitialiseGameMode();
    }


    // start one player game
    public void StartThreePlayerGame()
    {
        //player1Controller.player1IsComputer = false;


        //player2Controller.player2IsComputer = false;

        //player2Controller.isPlayer2 = true;


        //player3Controller.player3IsComputer = false;

        //player3Controller.isPlayer3 = true;


        //player4Controller.player4IsComputer = true;

        //player4Controller.isPlayer4 = false;


        InitialiseGameMode();
    }


    // start two player game
    public void StartFourPlayerGame()
    {
        //player1Controller.player1IsComputer = false;


        //player2Controller.player2IsComputer = false;

        //player2Controller.isPlayer2 = true;


        //player3Controller.player3IsComputer = false;

        //player3Controller.isPlayer3 = true;


        //player4Controller.player4IsComputer = false;

        //player4Controller.isPlayer4 = true;


        InitialiseGameMode();
    }


    // initialise score
    private void InitialiseScore()
    {
        // Game mode
        //player1Score = START_SCORE;
        //player2Score = START_SCORE;
        //player3Score = START_SCORE;
        //player4Score = START_SCORE;
    }


    // initialise
    private void InitialiseGameMode()
    {
        gameCredits -= 1;

        //UpdateGameCreditsText();

        if (gameCredits == INSERT_COINS)
        {
            canPlay = false;

            //AtariConsoleController.atariConsoleController.gameNumberSelected = AtariConsoleController.NO_GAME_SELECTED;

            //AtariConsoleController.atariConsoleController.SetGameSelection();
        }

        //pressStartText.gameObject.SetActive(false);

        //inPlayMode = true;
        inAttractMode = false;

        //AtariConsoleController.atariConsoleController.SetPawzModeSwitches();

        // hide atari console
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

        InitialiseScore();

        //winningScore = 0;

        // Disable player win text
        //player1WinsText.gameObject.SetActive(false);
        //player2WinsText.gameObject.SetActive(false);
        //player3WinsText.gameObject.SetActive(false);
        //player4WinsText.gameObject.SetActive(false);

        // Disable reset game text
        //resetText.gameObject.SetActive(false);

        // reset goals
        //player1Goal.gameObject.SetActive(false);
        //player2Goal.gameObject.SetActive(false);
        //player3Goal.gameObject.SetActive(false);
        //player4Goal.gameObject.SetActive(false);


        // reset score counters
        //player1ScoreCounter1.gameObject.SetActive(true);
        //player1ScoreCounter2.gameObject.SetActive(true);
        //player1ScoreCounter3.gameObject.SetActive(true);
        //player1ScoreCounter4.gameObject.SetActive(true);

        //player2ScoreCounter1.gameObject.SetActive(true);
        //player2ScoreCounter2.gameObject.SetActive(true);
        //player2ScoreCounter3.gameObject.SetActive(true);
        //player2ScoreCounter4.gameObject.SetActive(true);

        //player3ScoreCounter1.gameObject.SetActive(true);
        //player3ScoreCounter2.gameObject.SetActive(true);
        //player3ScoreCounter3.gameObject.SetActive(true);
        //player3ScoreCounter4.gameObject.SetActive(true);

        //player4ScoreCounter1.gameObject.SetActive(true);
        //player4ScoreCounter2.gameObject.SetActive(true);
        //player4ScoreCounter3.gameObject.SetActive(true);
        //player4ScoreCounter4.gameObject.SetActive(true);

        // initialise paddles
        //player1Controller.gameObject.SetActive(true);
        //player2Controller.gameObject.SetActive(true);
        //player3Controller.gameObject.SetActive(true);
        //player4Controller.gameObject.SetActive(true);


        //player1Controller.InitialiseSprite();

        //player2Controller.InitialiseSprite();

        //player3Controller.InitialiseSprite();

        //player4Controller.InitialiseSprite();
        
        
        // initialise dpads
        //SetGamePadControllers();


        // reset and enable ball
        //ballController.ResetBall(ballController.ballSpeed, ballController.ballSpeed);
    }


    // when a goal is scored . . .
    public void GoalScored(int playerScored)
    {
        if (!inAttractMode)
        {
            // update score
            UpdateScore(playerScored);

            IsGameOver(playerScored);
        }
    }


    // update score
    public void UpdateScore(int playerScored)
    {
        if (!inAttractMode)
        {
            switch (playerScored)
            {
                case PLAYER_ONE:

                    UpdatePlayer1Score();

                    break;

                case PLAYER_TWO:

                    UpdatePlayer2Score();

                    break;

                case PLAYER_THREE:

                    UpdatePlayer3Score();

                    break;

                case PLAYER_FOUR:

                    UpdatePlayer4Score();

                    break;
            }

            IsGameOver(playerScored);
        }
    }
          

    // update player 1 score
    public void UpdatePlayer1Score()
    {
        player1Score -= 1;

        ScoreController.scoreController.UpdateScoreDisplay(player1Score, ScoreController.PLAYER_1);

        if (player1Score == GAMEOVER_SCORE)
        {
            Player1Controller.player1.paddleTransform.gameObject.SetActive(false);

            Player1Controller.player1.goalTransform.gameObject.SetActive(true);
        }
    }


    // update player 2 score
    public void UpdatePlayer2Score()
    {
        player2Score -= 1;

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, ScoreController.PLAYER_2);

        if (player2Score == GAMEOVER_SCORE)
        {
            Player2Controller.player2.paddleTransform.gameObject.SetActive(false);

            Player2Controller.player2.goalTransform.gameObject.SetActive(true);
        }
    }


    // update player 3 score
    public void UpdatePlayer3Score()
    {
        player3Score -= 1;

        ScoreController.scoreController.UpdateScoreDisplay(player3Score, ScoreController.PLAYER_3);

        if (player3Score == GAMEOVER_SCORE)
        {
            Player3Controller.player3.paddleTransform.gameObject.SetActive(false);

            Player3Controller.player3.goalTransform.gameObject.SetActive(true);
        }
    }


    // update player 4 score
    public void UpdatePlayer4Score()
    {
        player4Score -= 1;

        ScoreController.scoreController.UpdateScoreDisplay(player4Score, ScoreController.PLAYER_4);

        if (player4Score == GAMEOVER_SCORE)
        {
            Player4Controller.player4.paddleTransform.gameObject.SetActive(false);

            Player4Controller.player4.goalTransform.gameObject.SetActive(true);
        }
    }


    // check if game over
    public void IsGameOver(int playerScored)
    {
        // check if player 1 has won
        if (player2Score == GAMEOVER_SCORE && player3Score == GAMEOVER_SCORE && player4Score == GAMEOVER_SCORE)
        {
            GameOver();
        }

        // player 2
        else if (player1Score == GAMEOVER_SCORE && player3Score == GAMEOVER_SCORE && player4Score == GAMEOVER_SCORE)
        {
            GameOver();
        }

        // player 3
        else if (player1Score == GAMEOVER_SCORE && player2Score == GAMEOVER_SCORE && player4Score == GAMEOVER_SCORE)
        {
            GameOver();
        }

        // player 4
        else if (player1Score == GAMEOVER_SCORE && player2Score == GAMEOVER_SCORE && player3Score == GAMEOVER_SCORE)
        {
            GameOver();
        }


        // otherwise,
        // reset ball and set colour for player scored
        switch (playerScored)
        {
            case PLAYER_ONE:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_ONE);

                break;

            case PLAYER_TWO:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_TWO);

                break;

            case PLAYER_THREE:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_THREE);

                break;

            case PLAYER_FOUR:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_FOUR);

                break;


        }

        //ballController.ResetBall(ballController.ballSpeed, ballController.ballSpeed);
    }


    // when the game is over
    private void GameOver()
    {
        gameOver = true;

        canPlay = false;

        inAttractMode = true;

        SetAttractModeState(inAttractMode);

        StartAttractMode();
    }


} // end of class
