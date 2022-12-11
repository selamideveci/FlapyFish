using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float maxTime;
    float _timer;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    float _randomY;
    void Start()
    {       
        //InstantiateObstacle();
    }    
    void Update()
    {
        if (!GameManager.gameOver && GameManager.gameStared)
        {
            _timer += Time.deltaTime;
            if (_timer >= maxTime)
            {   // Timer maxTime süresinen büyük oluðu sürece InstantiateObstacle çalýþtýr
                _randomY = Random.Range(minY, maxY);    // Random pozisyon oluþturur            
                InstantiateObstacle();
                _timer = 0;
            }
        }        
    }
    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(this.transform.position.x, _randomY);
    }
}
