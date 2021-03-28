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
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }    
    }

    public void noteHit()
    {
        Debug.Log("Hit on time");
        currentScore += (scorePerNote * multiplier);
        multiplier++;
        scoreText.text = "Score: " + currentScore;
        multiText.text = "Multiplier: x" + (multiplier - 1);
    }
    public void noteMiss()
    {
        Debug.Log("Missed");
        multiplier = 1;
        multiText.text = "Multiplier: x" + (multiplier - 1);
    }
}
