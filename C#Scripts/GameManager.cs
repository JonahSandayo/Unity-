using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState { Start, Playing, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public void TestPing() { Debug.Log("Ping!"); }
    public float obstacleSpeed = 5f;           
    public float speedIncreaseInterval = 5f; 
    public float speedIncreaseAmount = 0.5f;  
    public TMP_Text scoreText; 
    private float score = 0f;

    private float speedTimer = 0f;

    private GameState currentState = GameState.Start;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        SetState(GameState.Start);
    }

    void Update()
    {
    if (currentState != GameState.Playing) return;

    score += Time.deltaTime * 10f;  
    scoreText.text = "SCORE: " + Mathf.FloorToInt(score).ToString();

    speedTimer += Time.deltaTime;
    if (speedTimer >= speedIncreaseInterval)
    {
        obstacleSpeed += speedIncreaseAmount;
        speedTimer = 0f;
        Debug.Log("速度アップ！今の速さ: " + obstacleSpeed);
    }

    }

    /* ===== ボタンが呼ぶメソッド ===== */
    public void OnClickStart()
    {
        SetState(GameState.Playing);
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* ===== プレイヤーが呼ぶメソッド ===== */
    public void GameOver()
    {
        if (currentState != GameState.Playing) return;
        SetState(GameState.GameOver);
    }



    private void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Start:
                startPanel.SetActive(true);
                gameOverPanel.SetActive(false);
                Time.timeScale = 0f;   // ゲーム停止
                break;

            case GameState.Playing:
                startPanel.SetActive(false);
                gameOverPanel.SetActive(false);
                Time.timeScale = 1f;   // ゲーム進行
                break;

            case GameState.GameOver:
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;   // 止める
                break;
        }
    }
}

