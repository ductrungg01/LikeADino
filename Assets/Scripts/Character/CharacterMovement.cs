using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Transform transform; 

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    public void Translate(Vector3 move)
    {
        transform.Translate(move, Space.World);

        ClampCharacterWithinScreen();
    }

    void ClampCharacterWithinScreen()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        transform.position = pos;
    }
}
