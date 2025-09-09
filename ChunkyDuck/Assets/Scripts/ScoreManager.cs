using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public StabilityMeter sm;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public Text scoreText;
    static int comboScore;
    static int score;
    static int multiplier = 1;
    static int currentcombo;
    void Start()
    {
        Instance = this;
        comboScore = 0;
        score = 0;
        currentcombo = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        score += 100;
        currentcombo++;
        if(Instance.sm != null){
        Instance.sm.ShrinkBar();
        Debug.Log("shrinking");
        }
        else{
            Debug.Log("bar missing");
        }
        if(currentcombo == 5){
            multiplier++;
            currentcombo = 0;
        }
        Instance.hitSFX.Play();

    }
    public static void Miss()
    {
        comboScore = 0;
        if(score <=74){
            score = 0;
        }
        else{
        score -= 75;
        }
        currentcombo = 0;
        if(multiplier == 2){
            multiplier = 1;
        }
        if(multiplier > 2){
            multiplier-=2;
        }
       
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = "Score: "+score.ToString() + " x " + multiplier.ToString();
        scoreText.text += "\nCombo: "+comboScore.ToString();
    }
    public static int GetScore()
    {
        return score;
    }
    public static int GetMultiplier(){
        return multiplier;
    }
    public static void ModifyScore(int amount)
    {
        score = Mathf.Max(0, score + amount);
    }

    public static void ModifyMult(int newMult)
    {
        multiplier = Mathf.Max(0, newMult);
    }
}