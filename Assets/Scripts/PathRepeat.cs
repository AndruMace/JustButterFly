using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathRepeat : MonoBehaviour
{
    
    public GameObject player;
    public GameObject groundPlane;
    Vector3 nextPos;
    float next;
    float x = 0;
    // Start is called before the first frame update

    void Start()
    {
        next = 750;
    }

    void SpawnPath()
    {
        nextPos = new Vector3(0,0,next);
        Instantiate(groundPlane, nextPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= x)
        {
            // Debug.Log("test");
            SpawnPath();
            next += 750;
            x += 375;
        }
    }
}
