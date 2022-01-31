using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform[] wayPoints;
    public int index = 0;   
    public AudioSource audioController;
    public AudioSource audioController2;
    public GameObject GameOver;
    public float WaitGameOver = 5.0f;
    public bool CheckGameOver;
    void Start()
    {
        /*
        foreach (Transform t in wayPointsGo.transform)
        {
            Vector2 v2 = new Vector2(t.transform.position.x, t.transform.position.y);
            wayPoints.Add(v2);
        }
        audioController = GetComponent<AudioSource>();
        //LoadPath(wayPointsGo[Random.Range(0,3)]);
        */
    }
    public void FixedUpdate()
    {
        //Vector2 temp = new Vector2(this.transform.position.x, this.transform.position.y);
            if (transform.position != wayPoints[index].position)
            {
                Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[index].position, speed);
                GetComponent<Rigidbody2D>().MovePosition(temp);
            }
            else
            {
                index = (index + 1) % wayPoints.Length;
            }


        Vector2 dir = wayPoints[index].position -transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

        GameOverOrNot();
    }

    void GameOverOrNot()
    {
        if (CheckGameOver == true)
        {
            if (WaitGameOver > 0)
            {
                WaitGameOver -= Time.deltaTime;
            }
            else
            {
                CheckGameOver = false;
                WaitGameOver = 0;
                SceneManager.LoadScene(1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PacStudent")
        {
            if (collision.gameObject.GetComponent<PacStudentController>().PacStatus == false)
            {
                collision.gameObject.SetActive(false);
                GameOver.SetActive(true);
                audioController.Play();
            }
            else
            {
                Destroy(this.gameObject);
                audioController2.Play();
            }          
           
        }
        /*
        if (collision.gameObject.GetComponent<PowerPellets>().ScareOrNot == true)
        {

        }
        */
    }

}
