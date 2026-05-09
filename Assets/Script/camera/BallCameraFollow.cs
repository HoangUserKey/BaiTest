using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 playerOffset =
        new Vector3(0, 10, -12);

    public Vector3 ballOffset =
        new Vector3(0, 6, -8);

    public float smoothSpeed = 8f;

    Transform currentTarget;

    Coroutine returnCoroutine;

    void Start()
    {
        currentTarget = player;
    }

    void LateUpdate()
    {
        if (currentTarget == null) return;

        Vector3 offset;

        // nếu đang theo player
        if (currentTarget == player)
        {
            offset = playerOffset;
        }
        else
        {
            offset = ballOffset;
        }

        Vector3 desiredPosition =
            currentTarget.position + offset;

        transform.position =
            Vector3.Lerp(
                transform.position,
                desiredPosition,
                smoothSpeed * Time.deltaTime);

        transform.LookAt(currentTarget);
    }

    public void FollowBall(Transform ball)
    {
        // follow bóng
        currentTarget = ball;

        // tránh coroutine cũ chạy chồng
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine);
        }

        returnCoroutine =
            StartCoroutine(ReturnToPlayer());
    }

    IEnumerator ReturnToPlayer()
    {
        // đợi bóng bay
        yield return new WaitForSeconds(2f);

        // quay về player
        currentTarget = player;
    }
}
