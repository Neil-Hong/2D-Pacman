using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellets : MonoBehaviour
{
    public bool ScareOrNot;
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
            ScareOrNot = true;
            audioController.Play();
        }
    }
}
