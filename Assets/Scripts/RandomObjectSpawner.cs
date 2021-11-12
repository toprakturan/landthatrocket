using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{

    //HOW TO USE 
    //1.Create an empty game object on the scene and add this code to the game object.
    //Please change gizmos color to red (from inspector) to make game object more visible.
    //2.You can then adjust the size of the empty game object by seeing it on the scene.
    //Objects will be spawning in red the area you set.
    //You can set the timer in inspector.

    //Main definations for spawn mechanic
    public GameObject spawnObject;
    public bool stopSpwaning = false;
    public float spawnTime;
    public float spawnDelay;

    //Definations for spawning area
    private Vector3 origin;
    private Vector3 range;
    private Vector3 randomRange;
    private Vector3 randomCoordinate;

    //Make visible spawn area for scene view
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    private bool _isCollidePlayer;


    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

        //Get origin and range from spawner to calculate area
        origin = transform.position;
        range = transform.localScale / 2.0f;

        Debug.Log(origin);
        Debug.Log(range);

    }

    private void Update()
    {
        //Generate random coordinates in area 
        randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
        randomCoordinate = origin + randomRange;

        _isCollidePlayer = MeteorBehavior.Current.isCollidePlayer;
        
        if(_isCollidePlayer == true)
        {
            stopSpwaning = true;
        }
        else
        {
            stopSpwaning = false;
        }

        Debug.Log(_isCollidePlayer);
    }


    //To show spawn area in scene view not too important
    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    //This is a function to spawn object
    public void SpawnObject()
    {
        Instantiate(spawnObject, randomCoordinate, transform.rotation);
        if (stopSpwaning)
        {
            CancelInvoke("SpawnObject");
        }
    }

}