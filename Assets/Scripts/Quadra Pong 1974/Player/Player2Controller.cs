
using UnityEngine;

//
// Quadra Pong Atari 1974 v2019.02.28
//
// v2023.12.29
//


public class Player2Controller : MonoBehaviour
{
    public static Player2Controller player2;

    public Transform paddleTransform;

    public Transform goalTransform;

    public Rigidbody2D paddleRigidbody;

    // speed of paddle
    public float paddleSpeed;

    public float paddleLength;

    //public float paddleDirection;
    public Vector2 paddleDirection;

    // player start position
    private float paddlePositionX;

    private float paddlePositionY;

    private float paddlePositionOffset;

    private Vector2 paddleStartPosition;

    // ai check
    public bool player2IsComputer;


    private void Awake()
    {
        player2 = this;
    }


    private void Update()
    {
        PaddleController();
    }


    private void FixedUpdate()
    {
        paddleRigidbody.velocity = paddleDirection * paddleSpeed;
    }


    public void Initialise()
    {
        // speed of paddle
        if (GameController.gameController.inAttractMode || player2IsComputer)
        {
            paddleSpeed = 7f; //5f;
        }

        else
        {
            paddleSpeed = 10f; //6f;
        }

        // reset paddle position
        paddlePositionX = 7.6f; //6f;

        paddlePositionY = 0f;

        paddlePositionOffset = 0.5f;

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
        //paddleDirection = GameController.STOPPED;
        paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);

        if (Input.GetKey(KeyCode.P))
        {
            //paddleDirection = GameController.UP;

            MoveUp();
        }


        if (Input.GetKey(KeyCode.L))
        {
            //paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void ComputerController()
    {
        //paddleDirection = GameController.STOPPED;
        paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);

        //if (paddleTransform.position.y < BallController.ballController.ballTransform.position.y)
        if (BallController.ballController.ballTransform.position.y > paddleTransform.position.y + paddlePositionOffset)
        {
            //paddleDirection = GameController.UP;

            MoveUp();
        }


        //if (paddleTransform.position.y > BallController.ballController.ballTransform.position.y)
        else if (BallController.ballController.ballTransform.position.y < paddleTransform.position.y - paddlePositionOffset)
        {
            //paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void MoveUp()
    {
        /*if (paddleTransform.position.y < GameController.UPPER_BOUNDARY)
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
        }*/

        paddleDirection = new Vector2(paddlePositionX, GameController.UP);
    }


    private void MoveDown()
    {
        /*if (paddleTransform.position.y > GameController.LOWER_BOUNDARY)
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
        }*/

        paddleDirection = new Vector2(paddlePositionX, GameController.DOWN);
    }


} // end of class
