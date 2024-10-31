using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterAsset", menuName = "Scriptable Objects/CharacterAsset")]
public class CharacterAssetSO : ScriptableObject
{
    public Sprite head;
    public Sprite neck;
    public Sprite body;

}
