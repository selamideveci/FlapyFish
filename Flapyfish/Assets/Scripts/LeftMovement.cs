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
            _box = GetComponent<BoxCollider2D>();   // Ground objesinin BoxCollider2D compenentine eri�
            _groundWith = _box.size.x;  // _groundWith geni�li�i _box.size.x de�erine g�re ayarla
        }    
        else if (gameObject.CompareTag("Obstacle"))
        {
            // _obstacleWidth size de�erini Column tag�na g�re sahnede ara ve Column objesinin size de�erini ata
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }
    
    void Update()
    {
        // Ground ve Obstacle objeleri -x y�n�nde hareket eder 
        if (!GameManager.gameOver)
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }        

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_groundWith)
            {
                // Ground objesinin x pozisyonu _groundWith de�erinden k���kse yeni konuma git
                transform.position = new Vector2(transform.position.x + 2 * _groundWith, transform.position.y);
            }
        } 
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - _obstacleWidth)
            {
                // Obstacle x y�n�ndeki pozisynu GameManager de tan�ml� olan (bottomLeft -Obstacle)  de�erinden k���kse yok et yani kameradan ��km��sa
                Destroy(gameObject);
            }           
        }
    }
}
