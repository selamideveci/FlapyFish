using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int _score; // Skore deðiþkeni
    int _highScore; // Skore deðiþkeni

    [SerializeField] private Text scoreTxt; // Skore Texti
    [SerializeField] private Text panelScoreTxt; // Skore Texti
    [SerializeField] private Text panelHighScoreTxt; // Skore Texti

    [SerializeField] private GameObject New;
    void Start()
    {
        _score = 0; // Baþlangýçta skore 0 baþlasýn
        scoreTxt.text = _score.ToString();  // Skore deðerini scoreTxt de göster
        panelScoreTxt.text = _score.ToString();  // Skore deðerini scoreTxt de göster

        _highScore = PlayerPrefs.GetInt("highScore");
        panelHighScoreTxt.text = _highScore.ToString();
    }    
    void Update()
    {
        
    }
    public void Scored()
    {
        // score deðerini arttýr ve scoreTxt de göster
        _score++;
        scoreTxt.text = _score.ToString();
        panelScoreTxt.text = _score.ToString();

        if (_score > _highScore)
        {
            // Eðer score 
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
