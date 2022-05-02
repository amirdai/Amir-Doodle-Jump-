using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovment : MonoBehaviour
{
    public int checkscore;
    public Text scoreText;
    public Text highscoretext;
    public float movmentPower=15;
    Rigidbody rb;
    public int score;
    public int scorecoins;

    public Sprite fallSprite;
    public Sprite upSprite;
    public Sprite bounceSprite;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        highscoretext.text = "High Score: "+PlayerPrefs.GetInt("HS").ToString();
        sprite = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        SpriteMatch();
        float horiztoalMovment = Input.GetAxis("Horizontal")*movmentPower;
        Vector3 newMovment = rb.velocity;
        newMovment.x = horiztoalMovment;
        rb.velocity = newMovment;
        Vector3 playerPos = new Vector3();
        float playerY = gameObject.transform.position.y;
        if(gameObject.transform.position.x>=5f)
        {
            playerPos.x = -4.9f;
            playerPos.y = playerY;
            gameObject.transform.position = playerPos;
            
        }
         if (gameObject.transform.position.x <= -5f)
        {
            playerPos.x = 4.9f;
            playerPos.y = playerY;
            gameObject.transform.position = playerPos;

        }
        checkscore = scorecoins + Mathf.RoundToInt(transform.position.y * 10);
        if (checkscore > score)
            score = checkscore;
        scoreText.text = score.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        int endscore = score;
        if(other.gameObject.GetComponent<Destroyer>()||other.gameObject.GetComponent<monster>())
        {
            if(endscore>PlayerPrefs.GetInt("HS"))
            {
                PlayerPrefs.SetInt("HS", endscore);
            }
        }
        if(other.gameObject.CompareTag("Platform"))
        {
            sprite.sprite = bounceSprite;
        }
    }
    private void SpriteMatch()
    {
        if (rb.velocity.y <0)
        {
            sprite.sprite = fallSprite;
        }
        if(rb.velocity.y>0)
        {
            sprite.sprite = upSprite;
        }

    }

    
}
