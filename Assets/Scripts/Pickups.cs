using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour, ICollectable
{
    public int Points { get; set; }

    public void PointsToCalculate(int pointsToAdd)
    {
        Points += pointsToAdd;
    }
}
