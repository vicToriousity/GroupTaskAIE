using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Adamo_Score : MonoBehaviour
{
   
    public TMP_Text speedText;
    public TMP_Text scoreText;
    public TMP_Text scoreLetterText;
    public int TrickCount = 0;
    public float ComboScore = 0;
    public float Score = 0;
    public float finalTrickCounter = 0;
    public float cooldown = 0f;
    public bool comboCalc = false;
    public GameObject speedTextObj;
    public GameObject scoreTextObj;
    public GameObject scoreLetterTextObj;
    public GameObject playerObject;
    public Move scriptRefrence;

    public float lameBar = 20f;
    public float coolBar = 50f;
    public float rockinBar = 100f;
    public float ballerBar = 150f;
    public float grindBar = 200f;
    public float punkBar = 250f;

    public int rankNO = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");
        scriptRefrence = playerObject.GetComponent<Move>();

        speedTextObj = GameObject.FindGameObjectWithTag("speedDisp");
        speedText = speedTextObj.GetComponent<TMP_Text>();

        scoreTextObj = GameObject.FindGameObjectWithTag("scoreDist");
        scoreText = scoreTextObj.GetComponent<TMP_Text>();

        scoreLetterTextObj = GameObject.FindGameObjectWithTag("scoreLetterDist");
        scoreLetterText = scoreLetterTextObj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrickCount == 0)
        {
            finalTrickCounter = 0;
        }

        else if (TrickCount >= 1 & TrickCount < 2)
        {
            finalTrickCounter = 1;
        }

        else if (TrickCount >= 2 & TrickCount < 4)
        {
            finalTrickCounter = 2;
        }

        else if (TrickCount >= 4 & TrickCount < 6)
        {
            finalTrickCounter = 4;
        }

        else
        {
            finalTrickCounter = 16;
        }

        speedText.text = ("Speed: " + (scriptRefrence.horizontalVelocity.ToString("F2")));

        ComboScore = ((TrickCount * finalTrickCounter) * scriptRefrence.horizontalVelocity);


        if (Input.GetKeyDown(KeyCode.A) && scriptRefrence.IsGrounded() == false && cooldown <= 0)
        {
            TrickCount++;
            cooldown = 0.5f;
        }

        if (scriptRefrence.IsGrounded())
        {

            TrickCount = 0;
            Score = Score + ComboScore;
            scoreText.text = ("Score: " + Score.ToString("F0"));
        }

        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }

        if ( comboCalc == true)
        {
            scoreText.text = ("Score: " + Score.ToString("F0"));
            comboCalc = false;
        }


        if (Score >= lameBar & Score < coolBar)
        {
            scoreLetterText.text = ("Rank: E");
            rankNO = 1;
        }
        if (Score >= coolBar & Score < rockinBar)
        {
            scoreLetterText.text = ("Rank: C");
            rankNO = 2;
        }
        if (Score >= rockinBar & Score < ballerBar)
        {
            scoreLetterText.text = ("Rank: B");
            rankNO = 3;
        }
        if (Score >= ballerBar & Score < grindBar)
        {
            scoreLetterText.text = ("Rank: A");
            rankNO = 4;
        }
        if (Score >= grindBar & Score < punkBar)
        {
            scoreLetterText.text = ("Rank: S");
            rankNO = 5;
        }
        if (Score >= punkBar)
        {
            scoreLetterText.text = ("Rank: PUNK!");
            rankNO = 6;
        }

    }
}
