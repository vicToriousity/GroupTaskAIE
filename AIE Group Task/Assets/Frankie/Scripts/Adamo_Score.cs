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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = ("Speed: " + (moveScriptReference.horizontalVelocity.ToString("F2")));

        ComboScore = (TrickCount * moveScriptReference.horizontalVelocity);


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
