using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int currentScore;
    public int multiplier;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public Text scoreText;
    public Text multiText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = 0;
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
                if(!theMusic.isPlaying) {
                    Time.timeScale = 0;
                }
            }
        }    
    }

    public void noteHit()
    {
        Debug.Log("Hit on time");
        // currentScore += (scorePerNote * multiplier);
        multiplier++;
        scoreText.text = "Score: " + currentScore;
        multiText.text = "Multiplier: x" + (multiplier - 1);
    }

    public void NormalHit() {
        currentScore += scorePerNote * multiplier;
        noteHit();
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote * multiplier;
        noteHit();
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote * multiplier;
        noteHit();
    }

    public void noteMiss()
    {
        Debug.Log("Missed");
        multiplier = 1;
        multiText.text = "Multiplier: x" + (multiplier - 1);
    }

}
