using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music Data", menuName = "Scriptable Objects/Music Data")]
public class MusicData : ScriptableObject
{
    [System.Serializable]
    public struct MusicDataItem
    {
        public float start;
        public float end;
        public int laneInGame;
    };

    public float length;
    public List<MusicDataItem> musicData = new List<MusicDataItem>();
}
