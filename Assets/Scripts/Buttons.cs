// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        Debug.Log(MuteAudio.muted);
        Debug.Log("test");
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
        FindObjectOfType<AudioManager>().Play("StartTheme");        
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop("StartTheme"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Mute()
    {
        MuteAudio.muted = !MuteAudio.muted;

        if (MuteAudio.muted)
        {
            FindObjectOfType<AudioManager>().Stop("StartTheme");
        } else
        {
            FindObjectOfType<AudioManager>().Play("StartTheme");
        }
        Debug.Log(MuteAudio.muted);
    }
}
