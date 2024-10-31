using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Character
{
    [SerializeField] private int rabbitLife = 5;

    public Rabbit()
    {
        this.life = rabbitLife;
    }
}
