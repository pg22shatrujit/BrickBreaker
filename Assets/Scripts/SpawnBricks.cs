using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] Brick brickPrefab;

    [SerializeField] List<Color> colorList;

    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        //y -> 0, 4
        //x -> 
        for(int i = 0; i < 10; i ++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
