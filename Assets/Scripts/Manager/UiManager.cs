using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour, IGameFlow
{
    public static UiManager Instance { get; private set; }

    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private GameObject ChooseCharacterPanel;
    [SerializeField] private GameObject GameoverPanel;
    [SerializeField] private TMP_Text TimeScaleText;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        PausePanel.SetActive(false);
        UpdatePoint(0);
    }

    public void ShowTimeScale(float timeScale)
    {
        TimeScaleText.gameObject.SetActive(true);

        TimeScaleText.text = $"x{timeScale}";

        StartCoroutine(HideTimeScaleText(1.5f));
    }

    IEnumerator HideTimeScaleText(float timeWait)
    {
        yield return new WaitForSeconds(timeWait);

        TimeScaleText.gameObject.SetActive(false);
    }


    public void OnFinishGame(EndGameType type)
    {
        if (type == EndGameType.LOSE)
        {
            GameoverPanel.SetActive(true);
        }
    }
        
    public void OnPauseGame()
    {
        Debug.Log("UI Pause Game");

        PausePanel.SetActive(true);
    }

    public void OnPrepareGame()
    {
        Debug.Log("UI Prepare Game");

        ChooseCharacterPanel.SetActive(true);
    }

    public void OnResumeGame()
    {
        Debug.Log("UI Resume Game");

        PausePanel.SetActive(false);
    }

    public void OnStartGame()
    {
        Debug.Log("UI Start Game");

        PausePanel.SetActive(false);
        ChooseCharacterPanel.SetActive(false);
    }

    public void UpdateLife(int life)
    {
        lifeText.text = life.ToString();
    }

    public void UpdatePoint(int point)
    {
        pointText.text = $"{point} P";
    }
}
