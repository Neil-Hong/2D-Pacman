using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class PacStudentController : MonoBehaviour
{
    public AudioSource audioController;
    //public ParticleSystem dust;
    public float speed = 0.25f;
    private Vector2 lastInput = Vector2.zero;
    public Text GhostScaredTime;
    public Text ScoreText;
    public Text GameTimerText;
    public float GameTimer = 60f;
    public float CountDown;
    public int Score = 0;
    public bool PacStatus;
    public bool gameend;
    public float endtime = 6.0f;
    public GameObject Win;
    private int i = 0;
    public GameObject Life3;


    // Start is called before the first frame update
    void Start()
    {
        lastInput = transform.position;
        audioController = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentInput = Vector2.MoveTowards(transform.position, lastInput, speed);
        GetComponent<Rigidbody2D>().MovePosition(currentInput);
    
            if (Input.GetKey(KeyCode.W) && Valid(Vector2.up))
            {
                lastInput = (Vector2)transform.position + Vector2.up;

            }
            if (Input.GetKey(KeyCode.A) && Valid(Vector2.left))
            {
                lastInput = (Vector2)transform.position + Vector2.left;

            }
            if (Input.GetKey(KeyCode.S) && Valid(Vector2.down))
            {
                lastInput = (Vector2)transform.position + Vector2.down;
            }
            if (Input.GetKey(KeyCode.D) && Valid(Vector2.right))
            {
                lastInput = (Vector2)transform.position + Vector2.right;

            }

        Vector2 dir = lastInput - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
        checkEatPowerPellet();
        Teleporters();
        WinOrNot();
        checkLife();
        GhostScaredTime.text = CountDown.ToString("00.00");
        ScoreText.text = Score.ToString();
        GameTimerText.text = GameTimer.ToString("00:00:00");
        GameTimer++;

    }

    private bool Valid(Vector2 dir)
    {
        //CreatDust();
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return(hit.collider == GetComponent<Collider2D>());
    }
    /*
    void CreatDust()
    {
        dust.Play();
    }
    */
    void WinOrNot()
    {
        if ((Score == 222) || (GameTimer == 3600f))
        {
            Win.SetActive(true);
            gameend = true;
        }
        if (gameend)
        {
            if (endtime > 0)
            {
                endtime -= Time.deltaTime;
            }
            else
            {
                gameend = false;
                endtime = 0;
                i++;
                SceneManager.LoadScene(0);
            }
        }
    }

    void checkLife()
    {
        if (i == 1)
        {
            Destroy(Life3);
        }
    }
    void checkEatPowerPellet()
    {
        if (CountDown > 0)
        {
            CountDown -= Time.deltaTime;
        }
        else
        {
            CountDown = 0;
        }
    }

    void Teleporters()
    {
        if (transform.position.x == 26f && transform.position.y == -14f)
        {
            transform.position = new Vector2(1f, -14f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "PowerPellet1") || (collision.gameObject.name == "PowerPellet2") || (collision.gameObject.name == "PowerPellet3") || (collision.gameObject.name == "PowerPellet4"))
        {
            CountDown = 10f;
            PacStatus = true;
        }
        if (collision.gameObject.tag == "Pellet")
        {
            Score++;
        }
    }
        void Update()
    {
        audioController.Play();
    }
}
