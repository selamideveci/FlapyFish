using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    BoxCollider2D _box;
    float _obstacleWidth;
    float _groundWith;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            _box = GetComponent<BoxCollider2D>();   // Ground objesinin BoxCollider2D compenentine eriþ
            _groundWith = _box.size.x;  // _groundWith geniþliði _box.size.x deðerine göre ayarla
        }    
        else if (gameObject.CompareTag("Obstacle"))
        {
            // _obstacleWidth size deðerini Column tagýna göre sahnede ara ve Column objesinin size deðerini ata
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }
    
    void Update()
    {
        // Ground ve Obstacle objeleri -x yönünde hareket eder 
        if (!GameManager.gameOver)
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }        

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_groundWith)
            {
                // Ground objesinin x pozisyonu _groundWith deðerinden küçükse yeni konuma git
                transform.position = new Vector2(transform.position.x + 2 * _groundWith, transform.position.y);
            }
        } 
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - _obstacleWidth)
            {
                // Obstacle x yönündeki pozisynu GameManager de tanýmlý olan (bottomLeft -Obstacle)  deðerinden küçükse yok et yani kameradan çýkmýþsa
                Destroy(gameObject);
            }           
        }
    }
}
