using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKickManager : MonoBehaviour
{
    public Transform player;

    public Transform leftTarget;
    public Transform rightTarget;

    public float kickForce = 8f;
    public BallCameraFollow cameraFollow;

    public void AutoKick()
    {
        GameObject[] balls =
            GameObject.FindGameObjectsWithTag("Ball");

        if (balls.Length == 0) return;

        GameObject farthestBall = null;

        float maxDistance = 0f;

        // tìm bóng xa player nhất
        foreach (GameObject ball in balls)
        {
            float distance =
                Vector3.Distance(
                    player.position,
                    ball.transform.position);

            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestBall = ball;
            }
        }

        if (farthestBall == null) return;

        Rigidbody rb =
            farthestBall.GetComponent<Rigidbody>();

        if (rb == null) return;

        // chọn khung thành gần bóng hơn
        float leftDistance =
            Vector3.Distance(
                farthestBall.transform.position,
                leftTarget.position);

        float rightDistance =
            Vector3.Distance(
                farthestBall.transform.position,
                rightTarget.position);

        Transform target;

        if (leftDistance < rightDistance)
        {
            target = leftTarget;
        }
        else
        {
            target = rightTarget;
        }

        // reset lực cũ
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // hướng sút
        Vector3 dir =
            (target.position -
             farthestBall.transform.position).normalized;

        // sút
        rb.AddForce(
            (dir + Vector3.up * 0.15f) * kickForce,
            ForceMode.Impulse);

        cameraFollow.FollowBall(
            farthestBall.transform);
        
    }
}
