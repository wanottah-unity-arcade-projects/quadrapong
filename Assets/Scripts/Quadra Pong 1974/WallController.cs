
using UnityEngine;
using System.Collections;

//
// Quadra Pong Atari 1974 v2019.02.28
//
// v2022.11.14
//


public class WallController : MonoBehaviour
{
    // When the ball bounces off the wall
    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (collidingObject.transform.CompareTag("Ball") && !GameController.gameController.inAttractMode)
        {
            // play a sound
            AudioController.audioController.PlayAudioClip("Wall Bounce");
        }
    }


} // end of class
