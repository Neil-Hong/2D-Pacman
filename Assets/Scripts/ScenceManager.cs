using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
