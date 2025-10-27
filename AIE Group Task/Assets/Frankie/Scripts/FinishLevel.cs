using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FinishLevel : MonoBehaviour
{

    public TMP_Text rankText;
    public GameObject rankTextObj;
    public GameObject scoreTSTextObj;
    public TMP_Text scoreTSText;
    // fish
    public GameObject adamObject;
    public Adamo_Score aDScore;
    
    // Start is called before the first frame update
    void Start()
    {
        

        adamObject = GameObject.FindGameObjectWithTag("EventSyatumrizz");
        aDScore = adamObject.GetComponent<Adamo_Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // need score so adam script ref, player object ot detect collision, balls
        
    }
    private void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            StartCoroutine("Deload");
            
        }
    }
    public IEnumerator Deload()
    {
        if (aDScore.rankNO >=2)
        {
            SceneManager.LoadScene("LevelOneFinish", LoadSceneMode.Additive);
        } 
        else
        {
            SceneManager.LoadScene("LevelOneFail", LoadSceneMode.Additive);
        }
        
        yield return null;
        rankTextObj = GameObject.FindGameObjectWithTag("RankFinishText");
        rankText = rankTextObj.GetComponent<TMP_Text>();
        scoreTSTextObj = GameObject.FindGameObjectWithTag("RankScoreText");
        scoreTSText = scoreTSTextObj.GetComponent<TMP_Text>();
        scoreTSText.text = ("Score: " + aDScore.Score.ToString("F0"));
        if (aDScore.rankNO == 0)
        {
            rankText.text = ("Rank: Not angry, just disappointed.");
        }
        if (aDScore.rankNO == 1)
        {
            rankText.text = ("Rank: Lame..");
        }
        if (aDScore.rankNO == 2)
        {
            rankText.text = ("Rank: Cool…");
        }
        if (aDScore.rankNO == 3)
        {
            rankText.text = ("Rank: Rockin");
        }
        if (aDScore.rankNO == 4)
        {
            rankText.text = ("Rank: Baller!");
        }
        if (aDScore.rankNO == 5)
        {
            rankText.text = ("Rank: Grindtastic!!");
        }
        if (aDScore.rankNO == 6)
        {
            rankText.text = ("Rank: PUNK AS HELL!!!");
        }
        SceneManager.UnloadSceneAsync("Moriiii");
    }
}
