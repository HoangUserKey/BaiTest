using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject confettiPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER VA CHAM: " + other.name);

        if (other.CompareTag("Ball"))
        {
            Debug.Log("GOALLLLLL");

            Instantiate(
               confettiPrefab,
               other.transform.position + Vector3.up * 2f,
               Quaternion.identity
            );
        }
    }
}
