using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Character
{
    [SerializeField] private int dogLife = 4;

    public Dog()
    {
        this.life = dogLife;
    }
}
