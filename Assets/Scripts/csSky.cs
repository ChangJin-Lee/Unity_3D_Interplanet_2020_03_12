using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSky : MonoBehaviour
{
    float Speed = 0.6f;

    Renderer myRenderer;

    public GameObject asteroid;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float ofs = Speed * Time.time;

        myRenderer.material.mainTextureOffset = new Vector2(0, -ofs);

        MakeAsteroid();
    }

    void MakeAsteroid()
    {
        if(Random.Range(0,1000) >= 980) // 등장하는 운석의 개수
        {
            Instantiate(asteroid);
        }
    }
}
