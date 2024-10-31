using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            PlayerController.Instance.UpdateLife();

            GameManager.Instance.OnPauseGame();
        }
    }
}
