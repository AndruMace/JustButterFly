// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    public GameObject obs;
    public TextMeshProUGUI scoreText;

    public float speed;
    public float jumpForce;
    public float BONUS_GRAV;

    private Rigidbody rb;
    [HideInInspector]
    public static int score;

    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        score= 0;
        rb = GetComponent<Rigidbody>();
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, speed*Time.deltaTime);

        vel = rb.velocity;
        vel.y-=BONUS_GRAV*Time.deltaTime*10;
        
        if (Input.GetKeyDown("space") || Input.GetMouseButton(0))
        {
            vel.y += jumpForce;
            // FindObjectOfType<AudioManager>().Play("Whoosh");
        }

        rb.velocity=vel;
    }

    void OnTriggerEnter(Collider other)
    {
        score +=1;
        scoreText.text = "" + score;
        FindObjectOfType<AudioManager>().Play("ScoreInc");
    }
}