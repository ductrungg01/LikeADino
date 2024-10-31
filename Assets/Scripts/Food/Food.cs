using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Food : MonoBehaviour
{
    protected int pointEachTime = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            PointManager.Instance.Increase(pointEachTime);
            UiManager.Instance.UpdatePoint(PointManager.Instance.GetPoint());

            Destroy(gameObject);
        }
    }
}
