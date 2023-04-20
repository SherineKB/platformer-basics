using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreValue = 0;

    public Text MyHighScoreText;
    private int HighScoreValue = 0;

    [SerializeField] private AudioSource coinSound;

    
    void Start()
    {
        HighScoreValue = PlayerPrefs.GetInt("High Score : ", 0);
        MyScoreText.text = "Score : " + ScoreValue;
        MyHighScoreText.text = "High Score : " + HighScoreValue;        
    }


    void Update()
    {      
       if (HighScoreValue < ScoreValue) // save the score
        {
            PlayerPrefs.SetInt("High Score : ", ScoreValue);           
        } 

       if (ScoreValue > HighScoreValue) // update the score in real time
        {
            MyHighScoreText.text = "High Score : " + ScoreValue;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            ScoreValue++;
            MyScoreText.text = "Score : " + ScoreValue ;

            coinSound.Play();
        }       
    }

    

}