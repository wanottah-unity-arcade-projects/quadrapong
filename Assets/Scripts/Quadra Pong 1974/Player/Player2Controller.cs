
using UnityEngine;

//
// Quadra Pong Atari 1974 v2021.04.13
//
// v2019.02.28
//


public class Player2Controller : MonoBehaviour
{
    public static Player2Controller player2;

    public Transform paddleTransform;

    public Transform goalTransform;

    // speed of paddle
    [HideInInspector] public float paddleSpeed;
    [HideInInspector] public float paddleDirection;

    // player start position
    private float paddlePositionX;
    private float paddlePositionY;

    private Vector2 paddleStartPosition;

    // ai check
    [HideInInspector] public bool player2IsComputer;


    private void Awake()
    {
        player2 = this;
    }


    private void Update()
    {
        PaddleController();
    }



    public void Initialise()
    {
        // speed of paddle
        if (GameController.gameController.inAttractMode || player2IsComputer)
        {
            paddleSpeed = 5f;
        }

        else
        {
            paddleSpeed = 6f;
        }

        // Reset paddle position
        paddlePositionX = 6f;
        paddlePositionY = 0f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        paddleTransform.gameObject.SetActive(true);

        goalTransform.gameObject.SetActive(false);
    }


    private void PaddleController()
    {
        if (GameController.gameController.canPlay || GameController.gameController.inAttractMode)
        {
            PlayerInput();
        }
    }


    private void PlayerInput()
    {
        if (player2IsComputer)
        {
            ComputerController();
        }

        else
        {
            KeyboardController();
        }
    }


    // player 1
    private void KeyboardController()
    {
        paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.W))
        {
            paddleDirection = GameController.UP;

            MoveUp();
        }


        if (Input.GetKey(KeyCode.S))
        {
            paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void ComputerController()
    {
        paddleDirection = GameController.STOPPED;

        if (paddleTransform.position.y < BallController.ballController.ballTransform.position.y)
        {
            paddleDirection = GameController.UP;

            MoveUp();
        }


        if (paddleTransform.position.y > BallController.ballController.ballTransform.position.y)
        {
            paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void MoveUp()
    {
        if (paddleTransform.position.y < GameController.UPPER_BOUNDARY)
        {
            if (player2IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(

                    paddleTransform.position,
                    new Vector3(paddleTransform.position.x, BallController.ballController.ballTransform.position.y, paddleTransform.position.z),
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position =
                    new Vector3(paddleTransform.position.x, paddleTransform.position.y + paddleSpeed * Time.deltaTime, paddleTransform.position.z);
            }
        }
    }


    private void MoveDown()
    {
        if (paddleTransform.position.y > GameController.LOWER_BOUNDARY)
        {
            if (player2IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(

                    paddleTransform.position,
                    new Vector3(paddleTransform.position.x, BallController.ballController.ballTransform.position.y, paddleTransform.position.z),
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position =
                    new Vector3(paddleTransform.position.x, paddleTransform.position.y - paddleSpeed * Time.deltaTime, paddleTransform.position.z);
            }
        }
    }


} // end of class
