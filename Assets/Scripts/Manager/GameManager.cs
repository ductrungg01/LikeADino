using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameFlow
{
    public static GameManager Instance { get; private set; }
    private GameState _currentState = GameState.PREPARE;

    [SerializeField] private GameConfig gameConfig;

    private PlayerController _playerController;
    private FoodGenerator _foodGenerator;
    private PointManager _pointManager;
    private PlayMusic _playMusic;

    #region Getters/Setters
    public GameState CurrentGameState
    {
        get
        {
            return Instance._currentState;
        }
        set
        {
            Instance._currentState = value;
        }
    }

    public GameConfig GetGameConfig()
    {
       return Instance.gameConfig;
    }
    #endregion

    private void Awake()
    {
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
        _playerController = FindObjectOfType<PlayerController>();
        _foodGenerator = FindObjectOfType<FoodGenerator>();
        _pointManager = FindObjectOfType<PointManager>();
        _playMusic = FindObjectOfType<PlayMusic>(); 
        OnPrepareGame();
    }

    private void FixedUpdate()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnFinishGame(EndGameType.WIN);
        }
    }

    public void OnPrepareGame()
    {
        CurrentGameState = GameState.PREPARE;

        _playMusic.OnStop();

        UiManager.Instance.OnPrepareGame();
    }

    float prevTimeScale = 1f;
    int cntTimePlay = 0;

    public void OnStartGame()
    {
        cntTimePlay++;

        if (cntTimePlay > 1)
        {
            Time.timeScale = Time.timeScale + 0.2f;
        }

        UiManager.Instance.ShowTimeScale(Time.timeScale);

        prevTimeScale = Time.timeScale;

        _Reset();
        _foodGenerator.OnStartGenerate();
        _playMusic.OnStart();

        CurrentGameState = GameState.PLAYING;

        UiManager.Instance.UpdateLife(_playerController.GetLife());

        PointManager.Instance.OnReset();
        UiManager.Instance.OnStartGame();
    }

    
    public void OnPauseGame()
    {
        if (CurrentGameState != GameState.PLAYING) return;

        _Reset();
        _playMusic.OnStop();

        CurrentGameState = GameState.PAUSING;
        prevTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        UiManager.Instance.OnPauseGame();
    }

    public void OnResumeGame()
    {
        if (CurrentGameState != GameState.PAUSING) return;

        CurrentGameState = GameState.PLAYING;
        Time.timeScale = prevTimeScale;
        
        _playMusic.OnStart();
        _foodGenerator.OnStartGenerate();

        UiManager.Instance.OnResumeGame();
    }

    public void OnFinishGame(EndGameType type)
    {
        _Reset();
        _playMusic.OnStop();

        if (CurrentGameState == GameState.FINISH) return;

        CurrentGameState = GameState.FINISH;

        Debug.Log($"Finish Game {type}");

        UiManager.Instance.OnFinishGame(type);

        if (type == EndGameType.WIN)
        {
            OnStartGame();
        }
    }

    private void _Reset()
    {
        Food[] foods = FindObjectsOfType<Food>();

        foreach (Food food in foods)
        {
            Destroy(food.gameObject);
        }
    }

    public void Replay()
    {
        cntTimePlay = 0;
        Time.timeScale = 1;

        OnStartGame();
    }
}
