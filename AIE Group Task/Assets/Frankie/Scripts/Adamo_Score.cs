using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Adamo_Score : MonoBehaviour
{
    public Move moveScriptReference;
    public TMP_Text speedText;
    public TMP_Text scoreText;
    public int TrickCount = 0;
    public float ComboScore = 0;
    public float Score = 0;
    public float finalTrickCounter = 0;



    // Start is called before the first frame update
    void Start()
    {
        
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

        speedText.text = ("Speed: " + (moveScriptReference.horizontalVelocity.ToString("F2")));

        ComboScore = ((TrickCount * finalTrickCounter) * moveScriptReference.horizontalVelocity);


        if (Input.GetKeyDown(KeyCode.A) && moveScriptReference.IsGrounded() == false)
        {
            TrickCount++;
        }

        if (moveScriptReference.IsGrounded())
        {

            TrickCount = 0;
            Score = Score + ComboScore;
            scoreText.text = ("Score: " + Score.ToString("F0"));
        }
    }
}
