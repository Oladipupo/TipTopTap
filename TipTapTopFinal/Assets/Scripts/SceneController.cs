using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public int score;
    public int inARow = 0;
    public int multipler;
    public int Total;
    public int TotalNotes;
	public int scoreTotal = 0;
	public Text scoreText;
    public RawImage star1; //https://www.pngkit.com/view/u2q8a9q8t4o0q8e6_neon-star-png-yellow-neon-png/
    public RawImage star2;
    public RawImage star3;
    public Canvas endGameScreen;
    public Canvas gameScreen;
    public Text endScore;
    public Text Multipler;
	public AudioSource song;




    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = findMaxScore();
        Debug.Log(scoreTotal);
        endGameScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    int findMaxScore() //this finds the max score we use it for the star system all we gotta do is give it the amount of notes
    {
        int tempMultiplier;
        int tempCount=0;
         for(int i = 1; i <= TotalNotes; i++){
            tempMultiplier = (i / 15)+1;
            tempCount += (20 * tempMultiplier);
        }
        return tempCount;
    }



    public void updateScore(int num)
    {
         //multipler stuff
        if (inARow > 15)
        {
            multipler = (inARow / 15)+1;
            Multipler.GetComponent<Text>().text = "X" + multipler;

        }
        else
        {
            multipler = 1;
            Multipler.GetComponent<Text>().text = "";
        }


        score += num * multipler;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.GetComponent<Text>().text = " "+ score;

    }

    public void EndGame()
    {
        song.Stop();
        int starAmount = scoreTotal-score;
        Debug.Log(starAmount);



		if (starAmount < (scoreTotal * 1 / 5)) //3 star
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
        else if(starAmount < (scoreTotal * 1 / 4))// 2 star
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = false;
        }
        else if (starAmount < (scoreTotal * 1 / 3))//1 star
        {
            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
        }
        else
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
        }




        endGameScreen.enabled = true;
        gameScreen.enabled = true;
        endScore.GetComponent<Text>().text = ""+score;

    }

}
