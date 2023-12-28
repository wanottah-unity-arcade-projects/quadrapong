
using UnityEngine;

//
// Quadra Pong Atari 1972 v2019.02.28
//
// v2022.11.14
//

public class CollisionController : MonoBehaviour
{
    // check if the ball has entered the goal
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            // play the 'goalScored' sound
            AudioController.audioController.PlayAudioClip("Goal Scored");
        }

        if (collidingObject.CompareTag("Player 1 Goal"))
        {
            GameController.gameController.UpdateScore(GameController.PLAYER_ONE);

            BallController.ballController.ResetBall(-BallController.ballController.ballSpeed, -BallController.ballController.ballSpeed);
        }

        if (collidingObject.CompareTag("Player 2 Goal"))
        {
            GameController.gameController.UpdateScore(GameController.PLAYER_TWO);

            BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
        }

        if (collidingObject.CompareTag("Player 3 Goal"))
        {
            GameController.gameController.UpdateScore(GameController.PLAYER_THREE);

            BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
        }

        if (collidingObject.CompareTag("Player 4 Goal"))
        {
            GameController.gameController.UpdateScore(GameController.PLAYER_FOUR);

            BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
        }
    }


    // when the ball bounces off the paddles
    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            if (collidingObject.gameObject.CompareTag("Player 1") || 
                collidingObject.gameObject.CompareTag("Player 2") ||
                collidingObject.gameObject.CompareTag("Player 3") ||
                collidingObject.gameObject.CompareTag("Player 4"))
            {
                // play a sound
                AudioController.audioController.PlayAudioClip("Paddle Bounce");
            }
        }
    }


    // if ball has collided with the paddle
    private void OnCollisionExit2D(Collision2D collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Player 1"))
        {
            // if the ball's movement speed is less than its maximum speed
            if (BallController.ballController.ballRigidbody.velocity.magnitude < BallController.ballController.maxBallSpeed)
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x *
                        BallController.ballController.ballSpeedIncrease,
                        BallController.ballController.ballRigidbody.velocity.y +
                        Player1Controller.player1.paddleDirection * BallController.ballController.ballBounceSpeed);
            }


            // otherwise, just change the bounce speed of the ball
            else
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x,
                        BallController.ballController.ballRigidbody.velocity.y +
                        Player1Controller.player1.paddleDirection * BallController.ballController.ballBounceSpeed);
            }
        }


        if (collidingObject.gameObject.CompareTag("Player 2"))
        {
            // if the ball's movement speed is less than its maximum speed
            if (BallController.ballController.ballRigidbody.velocity.magnitude < BallController.ballController.maxBallSpeed)
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x *
                        BallController.ballController.ballSpeedIncrease,
                        BallController.ballController.ballRigidbody.velocity.y +
                        Player2Controller.player2.paddleDirection * BallController.ballController.ballBounceSpeed);
            }


            // otherwise, just change the bounce speed of the ball
            else
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x,
                        BallController.ballController.ballRigidbody.velocity.y +
                        Player2Controller.player2.paddleDirection * BallController.ballController.ballBounceSpeed);
            }
        }
    }

} // end of class
