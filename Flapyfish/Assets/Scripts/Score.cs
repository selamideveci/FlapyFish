using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int _score; // Skore de�i�keni
    int _highScore; // Skore de�i�keni

    [SerializeField] private Text scoreTxt; // Skore Texti
    [SerializeField] private Text panelScoreTxt; // Skore Texti
    [SerializeField] private Text panelHighScoreTxt; // Skore Texti

    [SerializeField] private GameObject New;
    void Start()
    {
        _score = 0; // Ba�lang��ta skore 0 ba�las�n
        scoreTxt.text = _score.ToString();  // Skore de�erini scoreTxt de g�ster
        panelScoreTxt.text = _score.ToString();  // Skore de�erini scoreTxt de g�ster

        _highScore = PlayerPrefs.GetInt("highScore");
        panelHighScoreTxt.text = _highScore.ToString();
    }    
    void Update()
    {
        
    }
    public void Scored()
    {
        // score de�erini artt�r ve scoreTxt de g�ster
        _score++;
        scoreTxt.text = _score.ToString();
        panelScoreTxt.text = _score.ToString();

        if (_score > _highScore)
        {
            // E�er score 
            _highScore = _score;
            panelHighScoreTxt.text = _highScore.ToString();
            PlayerPrefs.SetInt("highScore", _highScore);
            New.SetActive(true);
        }
    }
    public int GetScore()
    {
        return _score;
    }
}
