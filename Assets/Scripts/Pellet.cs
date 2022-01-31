using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pellet : MonoBehaviour
{
    public AudioSource audioController;
    void start()
    {
        audioController = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PacStudent")
        {
            Destroy(gameObject);
            audioController.Play();
        }
    }

}
