using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform[] WayPoints;
    private int index = 0;
    public AudioSource audioController;

    void start()
    {
        audioController = GetComponent<AudioSource>();
    }
    public void FixedUpdate()
    {
        if (transform.position != WayPoints[index].position)
        {
            Vector2 temp = Vector2.MoveTowards(transform.position, WayPoints[index].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(temp);
        }
        else
        {
            index = (index + 1) % WayPoints.Length;
        }

        Vector2 dir = WayPoints[index].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX",dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pacman")
        {
            Destroy(collision.gameObject);
            audioController.Play();
        }
    }


}
