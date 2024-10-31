using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterPanel : MonoBehaviour
{
    public List<ButtonCharacter> characterBtns = new List<ButtonCharacter>();

    public void ChooseCharacter(ButtonCharacter btn)
    {
        UnselectAll();

        btn.Select();
    }

    void UnselectAll()
    {
        foreach (var btn in characterBtns)
        {
            btn.Unselect();
        }
    }


}
