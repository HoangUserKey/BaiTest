using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickManager : MonoBehaviour
{
    public BallController currentBall;

    public void Kick()
    {
        if (currentBall != null)
        {
            currentBall.Kick();
        }
    }
}
