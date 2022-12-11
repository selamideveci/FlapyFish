using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float _speed;
    int angle;
    int minAngle = -60;
    int maxAngle = 20;
    bool toruchedGround;
    public Sprite fishDied;
    SpriteRenderer _sp;
    Animator _anim;
    [SerializeField] private AudioSource swim,hit,point;

    public Score score;
    public GameManager gameManager;
    public ObstacleSpawner obstacleSpawner;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;       
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        FishSwim(); // Fish input hareket        
    }
    private void FixedUpdate()
    {
        FishRotation(); // Fish Rotasyonu
    }
    void FishSwim()
    {
        // Fish input hareket
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            if (!GameManager.gameStared)
            {
                swim.Play();
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                swim.Play();
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
            
        }
    }
    void FishRotation()
    {
        // Fish Rotasyonu
        if (_rb.velocity.y > 0)
        {
            // Yukarý giderken açýyý arttýr
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2f)
        {
            // Aþaðý inerken açýyý azalt
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }
        if (!toruchedGround)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            // Temas edilen obje Obstacle (Obstacle objelerinin arasýndan geçmiþ) ise Skor artýr
            //Debug.Log("Scoe!!!");
            score.Scored(); // Skor arttýrma fonk çalýþ
            point.Play();
        }    
        else if (collision.CompareTag("Column") && !GameManager.gameOver)
        {
            // GameOver
            gameManager.GameOver();
            FishDiedEffect();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Fish Ground temas ettiyse yok et
            if (!GameManager.gameOver)
            {
                // GameOver
                gameManager.GameOver();
                GameOver();
                FishDiedEffect();
            }
            else
            {
                Debug.Log("Player Died..!");
                // GameOver (Fish)
                gameManager.GameOver();
                GameOver();
                FishDiedEffect();
            }
        }
    }
    void FishDiedEffect()
    {
        hit.Play();
    }
    void GameOver()
    {
        toruchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _sp.sprite = fishDied;
        _anim.enabled = false;        
    }
}
