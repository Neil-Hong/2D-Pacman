using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public Sprite che;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject cherry = new GameObject();
        var s = cherry.AddComponent<SpriteRenderer>();
        s.sprite = che;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
