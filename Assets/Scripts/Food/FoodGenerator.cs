using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private List<Transform> lanePos = new List<Transform>();
    [SerializeField] private float timeToSpawn = 0.15f;
    [SerializeField] private MusicData music;

    
    private bool isEnable = false;

    private void Start()
    {
        StopAllCoroutines();
    }

    float currentTime = 0;
    int currentIndex = 0;
    float start = 0, end = 0;
    private int currentLane = 0;
    public void OnStartGenerate()
    {
        StopAllCoroutines();

        SetEnable(true);

        currentIndex = 0;
        currentTime = 0;

        start = music.musicData[currentIndex].start;
        end = music.musicData[currentIndex].end;
        currentLane = music.musicData[currentIndex].laneInGame;

        StartCoroutine(CreateNewDonut(timeToSpawn));
    }

    
    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime > music.length)
        {
            UpdateIndex(0);
            currentTime -= music.length;
        } 

        if (!isEnable && currentTime >= start)
        {
            SetEnable(true);
        } else if (isEnable && currentTime > end)
        {
            SetEnable(false);

            if (currentIndex + 1 == music.musicData.Count)
            {
                GameManager.Instance.OnFinishGame(EndGameType.WIN);
            }
            else 
                UpdateIndex(currentIndex + 1);
        } 
    }

    private void UpdateIndex(int index, float waitTime = 0f)
    {
        StartCoroutine(UpdateIndexCoroutine(index, waitTime));
    }

    private IEnumerator UpdateIndexCoroutine(int index, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        currentIndex = index;
        start = music.musicData[currentIndex].start;
        end = music.musicData[currentIndex].end;
        currentLane = music.musicData[currentIndex].laneInGame;
    }

    IEnumerator CreateNewDonut(float after)
    {
        yield return new WaitForSeconds(after);

        if (isEnable)
        {
            Vector3 pos = lanePos[currentLane].position;
            GameObject go = Instantiate(foodPrefab, new Vector3(pos.x, pos.y, pos.x), Quaternion.identity);
            go.name = $"Donut + {currentIndex}";
        }

        StartCoroutine(CreateNewDonut(after));
    }

    private void SetEnable(bool enable)
    {
        this.isEnable = enable;
    }
}
