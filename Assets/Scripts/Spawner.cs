using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //we'll change this to game objects
    [SerializeField] GameObject[] spawns;
    [SerializeField] float maxTime = 5f;
    [SerializeField] float minTime = 2f;
    [Header("Area Fill")]
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minX;
    [SerializeField] float minY;

    float time;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomTimeGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
            Spawn();
    }

    void RandomTimeGeneration()
    {
        time = Random.Range(maxTime, minTime);
    }
    void Spawn()
    {
        //we'll change these to gameobjects
        int index = Random.Range(0, spawns.Length);
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        GameObject spawn = Instantiate(spawns[index], transform.position + new Vector3(randX, randY), transform.rotation);
        RandomTimeGeneration();

    }

    public void DecreaseSpawnTime()
    {
        if(minTime >= 1)
            minTime -= 0.2f;
        if(maxTime >= (minTime + 1))
            maxTime -= 0.2f;
    }
    
}
