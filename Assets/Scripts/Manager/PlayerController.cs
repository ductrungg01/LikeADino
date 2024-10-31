using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private GameObject character_cat;
    [SerializeField] private GameObject character_dog;
    [SerializeField] private GameObject character_rabbit;

    private CharacterMovement characterMovement;
    private Character character;

    private Vector3 prevWorldPosition;

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


    public void ChooseCharacter(int index)
    {
        if (index == 0)
        {
            character = character_cat.GetComponent<Character>();
            character_cat.SetActive(true);
        } else if (index == 1)
        {
            character = character_dog.GetComponent<Character>();
            character_dog.SetActive(true);
        } else if (index == 2)
        {
            character = character_rabbit.GetComponent<Character>();
            character_rabbit.SetActive(true);
        }

        characterMovement = character.GetComponent<CharacterMovement>();

        GameManager.Instance.OnStartGame();

    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.PLAYING)
        {
            HandleMoving();
        } 
        else if (GameManager.Instance.CurrentGameState == GameState.PAUSING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.OnResumeGame();
            }
        }
    }

    void HandleMoving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            float differentX = currWorldPosition.x - prevWorldPosition.x;

            // If differentX < 0, character is look to the left
            if (differentX < -0.01f) 
                SetCharacterDirection(true);
            if (differentX > 0.01f) 
                SetCharacterDirection(false);

            characterMovement.Translate(new Vector3(differentX, 0, 0));

            prevWorldPosition = currWorldPosition;
        }
    }

    private void SetCharacterDirection(bool left)
    {
        if (left)
        {
            character.transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            character.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void UpdateLife(int amount = -1)
    {
        character.UpdateLife(amount);
    }

    public int GetLife()
    {
        return character.GetLife();
    }
}
