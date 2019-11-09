using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundRepeat : MonoBehaviour
{
    public GameObject[] plants;
    public GameObject player;
    public GameObject groundPlane;
    Vector3 nextPos;
    float next;
    float x = 0;
    int y;

    float rightSide = -10; //constant
    float bottom;
    float leftSide = -250; //constant
    float top;

    // Start is called before the first frame update
    List<GameObject> planeList = new List<GameObject>();
    List<GameObject> faunaList = new List<GameObject>();

    void Start()
    {
        next = 750;
        top = 375;
        bottom = -375;
        Populate();
        y=3;
    }

    void Populate()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                float ranX = Random.Range(rightSide - 10, leftSide);
                float ranZ = Random.Range(bottom, top);
                GameObject plant = Instantiate(plants[i], new Vector3(ranX, 0, ranZ), Quaternion.identity);
                int scale = Random.Range(20, 50);
                plant.transform.localScale = new Vector3(scale, scale + 5, scale);
                faunaList.Add(plant);

                GameObject border = Instantiate(plants[i], new Vector3(-260, 0, ranZ), Quaternion.identity);
                border.transform.localScale = new Vector3(scale, scale + 5, scale);
                faunaList.Add(border);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= x || y > 1)
        {
            nextPos = new Vector3(-110, (float)-0.01, next);
            planeList.Add(Instantiate(groundPlane, nextPos, Quaternion.identity));
            bottom += 750;
            top += 750;
            next += 750;
            x += 375;
            y=0;
            Populate();

            for (int i = planeList.Count - 1; i >= 0; i--)
            {
                if (planeList[i].transform.position.z - player.transform.position.z <= -385 )
                {
                    Destroy(planeList[i]);
                    planeList.Remove(planeList[i]);
                } 
            }

            for (int i = faunaList.Count - 1; i >= 0; i--)
            {
                if (faunaList[i].transform.position.z - player.transform.position.z <= -385)
                {
                    Destroy(faunaList[i]);
                    faunaList.RemoveAt(i);
                }
            }
        }

    }


}

