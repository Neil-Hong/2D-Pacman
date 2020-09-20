using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public AudioSource audioController;
    void start()
    {
        audioController = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pacman")
        {
            Destroy(gameObject);
            audioController.Play();
        }
    }

}
