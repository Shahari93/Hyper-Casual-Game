using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collected = other.GetComponent<ICollectable>();
        if (other.CompareTag("Good"))
        {
            collected.PointsToCalculate(1);
            score += collected.Points;
            Debug.Log(score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bad"))
        {
            collected.PointsToCalculate(1);
            score -= collected.Points;
            Debug.Log(score);
            Destroy(other.gameObject);
        }
    }
}
