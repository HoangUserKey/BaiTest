using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public GameObject kickButton;

    public KickManager kickManager;

    BallController ballController;

    void Awake()
    {
        // Lấy BallController từ object cha (Soccer Ball)
        ballController =
            GetComponentInParent<BallController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            kickButton.SetActive(true);

            // Gán quả bóng hiện tại
            kickManager.currentBall =
                ballController;

          //  Debug.Log("SHOW BUTTON");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            kickButton.SetActive(false);

            kickManager.currentBall = null;

            Debug.Log("HIDE BUTTON");
        }
    }

}
