using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject infoText;
    public GameObject player;

    private movement move;
    private int seconds;

 

    // Start is called before the first frame update
    void Start()
    {

        move = player.GetComponent<movement>();
        seconds = 3;
        StartCoroutine(StartGame());
        StartCoroutine(IncrementSeconds());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        move.enabled = true;
        countdownText.enabled = false;
        this.enabled = false;
    }

    IEnumerator IncrementSeconds()
    {
        while(seconds > 0)
        {
            countdownText.text = "" + seconds;
            yield return new WaitForSeconds(1);
            seconds -= 1;
        }

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void info()
    {
        infoText.SetActive(!infoText.active);
    }

}
