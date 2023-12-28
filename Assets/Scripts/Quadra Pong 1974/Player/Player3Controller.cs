
using UnityEngine;

//
// Quadra Pong Atari 1974 v2021.04.13
//
// v2019.02.28
//


public class Player3Controller : MonoBehaviour
{
    public static Player3Controller player3;

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
    [HideInInspector] public bool player3IsComputer;


    private void Awake()
    {
        player3 = this;
    }


    private void Update()
    {
        PaddleController();
    }



    public void Initialise()
    {
        // speed of paddle
        if (GameController.gameController.inAttractMode || player3IsComputer)
        {
            paddleSpeed = 5f;
        }

        else
        {
            paddleSpeed = 6f;
        }

        // Reset paddle position
        paddlePositionX = 0f;
        paddlePositionY = 6f;

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
        //if (player3IsComputer)
        //{
            ComputerController();
        //}

        //else
        //{
            //KeyboardController();
        //}
    }


    // player 1
    private void KeyboardController()
    {
        paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.W))
        {
            paddleDirection = GameController.LEFT;

            MoveLeft();
        }


        if (Input.GetKey(KeyCode.S))
        {
            paddleDirection = GameController.RIGHT;

            MoveRight();
        }
    }


    private void ComputerController()
    {
        paddleDirection = GameController.STOPPED;

        if (paddleTransform.position.x > BallController.ballController.ballTransform.position.x)
        {
            paddleDirection = GameController.LEFT;

            MoveLeft();
        }


        if (paddleTransform.position.x < BallController.ballController.ballTransform.position.x)
        {
            paddleDirection = GameController.RIGHT;

            MoveRight();
        }
    }


    private void MoveLeft()
    {
        if (paddleTransform.position.x > GameController.LEFT_BOUNDARY)
        {
            if (player3IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(

                    paddleTransform.position, 
                    new Vector3(BallController.ballController.ballTransform.position.x, paddleTransform.position.y, paddleTransform.position.z), 
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position = 
                    new Vector3(paddleTransform.position.x - paddleSpeed * Time.deltaTime, paddleTransform.position.y, paddleTransform.position.z);
            }
        }
    }


    private void MoveRight()
    {
        if (paddleTransform.position.x < GameController.RIGHT_BOUNDARY)
        {
            if (player3IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(

                    paddleTransform.position, 
                    new Vector3(BallController.ballController.ballTransform.position.x, paddleTransform.position.y, paddleTransform.position.z), 
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position = 
                    new Vector3(paddleTransform.position.x + paddleSpeed * Time.deltaTime, paddleTransform.position.y, paddleTransform.position.z);
            }
        }
    }


} // end of class
