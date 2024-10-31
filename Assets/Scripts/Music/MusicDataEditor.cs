using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MusicData))]
public class MusicDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MusicData musicData = (MusicData)target;

        if (GUILayout.Button("Generate Random Data"))
        {
            GenerateRandomData(musicData);
        }

        DrawDefaultInspector();
    }

    private void GenerateRandomData(MusicData musicData)
    {
        musicData.musicData.Clear();

        musicData.length = Random.Range(20, 40);
        float timeBeforeEnd = Random.Range(2f, 4f);
        float actualEnd = musicData.length - timeBeforeEnd;

        float prev = 1f;

        float MinLengthOfNode = 0.1f, MaxLengthOfNode = 1f;
        float MinLengthBetweenNode = 0.35f, MaxLengthBetweenNode = 0.5f;

        while (true)
        {
            MusicData.MusicDataItem newItem = new MusicData.MusicDataItem();

            newItem.start = Mathf.Min(actualEnd, Random.Range(prev + MinLengthBetweenNode, prev + MaxLengthBetweenNode));
            if (Mathf.Abs(actualEnd - newItem.start) < 0.00001) break;

            float _max = (Random.value < 0.2f ? MaxLengthOfNode : 0.2f);

            newItem.end = Mathf.Min(actualEnd, Random.Range(newItem.start + MinLengthOfNode, newItem.start + _max));
            newItem.laneInGame = Random.Range(0, 9);

            musicData.musicData.Add(newItem);
            if (Mathf.Abs(actualEnd - newItem.end) < 0.00001) break;

            prev = newItem.end;
        }


        EditorUtility.SetDirty(musicData);
    }
}
