// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollision : MonoBehaviour
{
    public Button retry;
    public Button home;
    public Button info;

    int lastHighscore;
    int retries;

    bool isDead;

    void Start()
    {
        retries = PlayerPrefs.GetInt("retries", 0);
        retry.interactable = false;
        home.interactable = false;
        info.interactable = false;
        isDead = false;
    }

    void SetHighscore()
    {
        lastHighscore = PlayerPrefs.GetInt("Highscore", 0);

        if (movement.score > lastHighscore)
        {
            PlayerPrefs.SetInt("Highscore", movement.score);
        }
    }

    void OnCollisionEnter()
    {
        if(!isDead) 
        {
            isDead = true;
            retries += 1;
            PlayerPrefs.SetInt("retries", retries);
        }
        if (retries % 5 == 0)
        {
            // AdController.instance.showVideoAd();
            Debug.Log(retries);
;        }
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("Death");
        // Debug.Log(movement.score);
        SetHighscore();
        retry.interactable = true;
        home.interactable = true;
        info.interactable = true;
        gameObject.SetActive(false);
    }

}
