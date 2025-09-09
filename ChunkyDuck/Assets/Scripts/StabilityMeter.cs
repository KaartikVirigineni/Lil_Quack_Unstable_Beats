using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilityMeter : MonoBehaviour
{
    public RectTransform barRect; 
    public float shrinkAmount = 10f;
    public Text warning;
    private Vector2 size;
    private bool done = false;
    private bool used = false;
    
    public void ShrinkBar()
    {
        size = barRect.sizeDelta;
        size.y -= shrinkAmount;
        if (size.y < 0){
            size.y = 0; 
            done = true; 
        }
        barRect.sizeDelta = size;
    }
    public void Update(){
        if(size.y == 0 && done && !used){
        warning.gameObject.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Space)){
            RandomEffect();
            used = true;
        }
    }
    }
    public void RandomEffect(){
        int effect = Random.Range(0,5);
        if(effect == 0){
            Debug.Log("+10Mult");
            ScoreManager.ModifyMult(ScoreManager.GetMultiplier() + 10);
            warning.text = "+10 Multipler";
        }
        else if(effect == 1){
            Debug.Log("Score/2");
            ScoreManager.ModifyScore(-ScoreManager.GetScore() / 2);
            warning.text = "Score Halved";
        }
        else if(effect == 2){
            Debug.Log("Mult*2");
            ScoreManager.ModifyMult(ScoreManager.GetMultiplier() * 2);
            warning.text = "Multiplier x2";
        }
        else if(effect == 3){
            Debug.Log("+1000");
            ScoreManager.ModifyScore(1000);
            warning.text = "+1000 Score";
        }
        else{
            Debug.Log("Mult/2");
            ScoreManager.ModifyMult(ScoreManager.GetMultiplier() /2);
            warning.text = "Multiplier Halved";
        }
    }
}

