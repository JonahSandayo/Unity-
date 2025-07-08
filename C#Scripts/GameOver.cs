using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return; 

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("ゲームオーバー！！");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
