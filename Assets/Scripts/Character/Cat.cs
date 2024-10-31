using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character
{
    [SerializeField] private int catLife = 3;

    public Cat()
    {
        this.life = catLife;
    }

}
