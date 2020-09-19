using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public AudioSource audioController;
    public float spped = 0.25f;
    private Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        audioController = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, spped);
        GetComponent<Rigidbody2D>().MovePosition(temp);
    }

    void Update()
    {
        audioController.Play();
    }
}
