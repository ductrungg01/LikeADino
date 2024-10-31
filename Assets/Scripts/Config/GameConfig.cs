using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Tools/Create new game config")]
public class GameConfig : ScriptableObject
{
    public int life = 3;
}
