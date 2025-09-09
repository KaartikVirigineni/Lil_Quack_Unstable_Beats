using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SongOver : MonoBehaviour
{
    public RectTransform songOverPanel;
    public float slideSpeed = 500f;
    public float targetY = 0f; 
    public float delayBeforeSlide = 2f; 
    public int high;
    public int mid;
    public string[] good = new string[5];
    public string[] ok = new string[5];
    public string[] bad = new string[5];

    private int random = 0;
    private bool slideIn = false;
    private int score;
    private int mult;

    public Text scoreText;
    public Text comment;
    public GameObject next;
    public bool final = false;

    void Start()
    {
        if(!final){
        next.SetActive(false);
        }
        Vector2 pos = songOverPanel.anchoredPosition;
        songOverPanel.anchoredPosition = new Vector2(pos.x, pos.y + 300);
    }

    void Update()
    {
        if (slideIn)
        {
            Vector2 current = songOverPanel.anchoredPosition;
            Vector2 target = new Vector2(current.x, targetY);

            songOverPanel.anchoredPosition = Vector2.MoveTowards(current, target, slideSpeed * Time.deltaTime);
        }
    }

    public void ShowSongOver()
    {
        score = ScoreManager.GetScore();
        mult = ScoreManager.GetMultiplier();
        scoreText.text = "Score: " + score * mult;

        random = Random.Range(0, 5);
        if (score * mult >= high){
            comment.text = good[random];
            if(!final){
            next.SetActive(true);
            }
        }
        else if (score * mult >= mid){
            comment.text = ok[random];
            if(!final){
            next.SetActive(true);
            }
        }
        else{
            comment.text = bad[random];
        }

        StartCoroutine(DelayedSlideIn());
    }

    IEnumerator DelayedSlideIn()
    {
        yield return new WaitForSeconds(delayBeforeSlide);
        slideIn = true;
    }
}
