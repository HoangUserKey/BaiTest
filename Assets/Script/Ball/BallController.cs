using System.Collections;
using System.Linq;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform leftTarget;

    public Transform rightTarget;

    public float kickForce = 20f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Kick()
    {
        Transform target;

        float leftDistance =
            Vector3.Distance(
                transform.position,
                leftTarget.position);

        float rightDistance =
            Vector3.Distance(
                transform.position,
                rightTarget.position);

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

        Vector3 dir =
            (target.position - transform.position).normalized;

        rb.AddForce(
            (dir + Vector3.up * 0.2f) * kickForce,
            ForceMode.Impulse);

        // CAMERA FOLLOW BÓNG
        FindObjectOfType<BallCameraFollow>()
            .FollowBall(transform);
    }

    Transform GetNearestTarget()
    {
        float leftDistance =
            Vector3.Distance(
                transform.position,
                leftTarget.position);

        float rightDistance =
            Vector3.Distance(
                transform.position,
                rightTarget.position);

        if (leftDistance < rightDistance)
        {
            return leftTarget;
        }

        return rightTarget;
    }
}