using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallRepeat : MonoBehaviour
{
    
    public GameObject player;
    public GameObject wallPlane;
    Vector3 nextPos;
    float next;
    float x = 0;


    void Start()
    {
        next = 750;
    }

    void SpawnPath()
    {
        nextPos = new Vector3((float)10.01, 85, next);
        Instantiate(wallPlane, nextPos, Quaternion.identity);
    }

    void Update()
    {
        if (player.transform.position.z >= x)
        {
            SpawnPath();
            next += 750;
            x += 375;
        }
    }
}
