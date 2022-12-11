using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;  // Diðer scriptlerden eriþim saðlar
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject getReady;
    public GameObject score;

    public static int gameScore;
    public static bool gameStared;
    public Score scoreScprit;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); // Cameranýn sol alt konumunu ayarlar
    }
    void Start()
    {
        gameOver = false;
        gameStared = false;
    }    
    void Update()
    {
        
    }
    public void GameHasStarted()
    {
        gameStared = true;
        getReady.SetActive(false);
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Yeniden baþlat
    }
    public void GameOver()
    {
        // gameOverPanel paneli aktif hale getir ve gameEver true dönerek oyun biter
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = scoreScprit.GetScore();
    }
}
