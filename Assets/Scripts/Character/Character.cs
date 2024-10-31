using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterType currentType;

    [SerializeField] private GameObject body;
    [SerializeField] GameObject neck;
    
    private Vector3 neckPos;

    private List<GameObject> neckList = new List<GameObject>();
    protected int life = 1;


    protected void Start()
    {
        neckList.Add(neck);
        neckPos = new Vector3(neck.transform.localPosition.x, neck.transform.localPosition.y, neck.transform.localPosition.z);
    }

    private void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.M))
        {
            CreateNewNeck();
        }
    }

    [SerializeField] private float offsetY = -0.25f;
    [SerializeField] private GameObject spritesParent;
    public void CreateNewNeck()
    {
        body.transform.Translate(new Vector3(0, offsetY, 0));

        foreach (GameObject neck in neckList)
        {
            neck.transform.Translate(new Vector3(0, offsetY, 0));
        }

        GameObject go = Instantiate(neck);
        go.transform.SetParent(spritesParent.transform, false);
        go.transform.localPosition = new Vector3(neckPos.x, neckPos.y, neckPos.z);

        neckList.Add(go);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            CreateNewNeck();
        }
    }

    public void UpdateLife(int amount = -1)
    {
        life += amount;

        UiManager.Instance.UpdateLife(life);

        if (life < 0)
        {
            GameManager.Instance.OnFinishGame(EndGameType.LOSE);
        }
    }

    public int GetLife()
    {
        return life;
    }
}
