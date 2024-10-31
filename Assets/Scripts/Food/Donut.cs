using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : Food
{
    [SerializeField] private int pointOfDonut = 1;

    public Donut()
    {
        this.pointEachTime = pointOfDonut;
    }
}
