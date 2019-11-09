// using System.Collections;
// using System.Collections.Generic;
// using System;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    System.Random ran = new System.Random();
    public GameObject obs;
    public GameObject player;
    private Vector3 old_pos; 

    // Start is called before the first frame update
    void Start()
    {
        old_pos = player.transform.position;
        SpawnObs();
    }

    void SpawnObs() 
    {
        int y = ran.Next(10,40);
        float z = player.transform.position.z + 250;
        Instantiate(obs, new Vector3(0, y, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - old_pos.z > 50)
        {
            SpawnObs();
            old_pos = player.transform.position;
        }
    }
}
