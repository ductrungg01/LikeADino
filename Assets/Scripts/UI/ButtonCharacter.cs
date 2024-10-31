using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCharacter : MonoBehaviour
{
    private Image border;

    private void Start()
    {
        border = GetComponent<Image>();
    }

    public void Select()
    {
        border.color = Color.green;
    } 

    public void Unselect()
    {
        border.color = Color.white;
    }
}
