
using UnityEngine;

//
// Quadra Pong Atari 1974 v2019.02.28
//
// v2023.12.29
//


public class Player4Controller : MonoBehaviour
{
    public static Player4Controller player4;

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
    public bool player4IsComputer;


    private void Awake()
    {
        player4 = this;
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
        if (GameController.gameController.inAttractMode || player4IsComputer)
        {
            paddleSpeed = 7f; //5f;
        }

        else
        {
            paddleSpeed = 10f; //6f;
        }

        // Reset paddle position
        paddlePositionX = 0f;

        paddlePositionY = -8.08f; //-6f;

        paddlePositionOffset = 0.5f;

        paddleLength = 3f;

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


    // player 4
    /*private void KeyboardController()
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
    }*/


    private void ComputerController()
    {
        //paddleDirection = GameController.STOPPED;
        

        //if (paddleTransform.position.x > BallController.ballController.ballTransform.position.x)
        if (BallController.ballController.ballTransform.position.x < paddleTransform.position.x - paddlePositionOffset)
        {
            //paddleDirection = GameController.LEFT;

            MoveLeft();
        }


        //if (paddleTransform.position.x < BallController.ballController.ballTransform.position.x)
        else if (BallController.ballController.ballTransform.position.x > paddleTransform.position.x + paddlePositionOffset)
        {
            //paddleDirection = GameController.RIGHT;

            MoveRight();
        }

        else
        {
            paddleDirection = new Vector2(GameController.STOPPED, paddlePositionY);
        }
    }


    private void MoveLeft()
    {
        /*if (paddleTransform.position.x > GameController.LEFT_BOUNDARY)
        {
            if (player4IsComputer)
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
        }*/

        paddleDirection = new Vector2(GameController.LEFT, paddlePositionY);
    }


    private void MoveRight()
    {
        /*if (paddleTransform.position.x < GameController.RIGHT_BOUNDARY)
        {
            if (player4IsComputer)
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
        }*/

        paddleDirection = new Vector2(GameController.RIGHT, paddlePositionY);
    }


} // end of class
