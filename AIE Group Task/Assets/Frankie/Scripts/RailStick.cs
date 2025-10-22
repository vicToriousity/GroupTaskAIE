using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class RailStick : MonoBehaviour
{
    //basic stuff
    public Collider2D railCollider;
    private bool railGrind;
    public GameObject playerObject;
    public GameObject adamObject;
   

    //jump off rail
    public float railJumpBurstRight = 1f;
    public float railJumpBurstUp = 4f;
   
 


    //combo stuff
    private bool pressA;
    private bool starting = true;
    private int comboScore = 0;
    private float finalScore = 0;
    

    //maths
    //angle is 35
    


    //scriptrefences
    public Move scriptRefrence;
    public Adamo_Score aDScore;



    // Start is called before the first frame update
    void Start()
    {
        railCollider = GetComponent<Collider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        scriptRefrence = playerObject.GetComponent<Move>();
        adamObject = GameObject.FindGameObjectWithTag("EventSyatumrizz");
        //groundCheckGO = GameObject.FindGameObjectWithTag("groundCheck");
       // groundCheck = groundCheckGO.GetComponent<Transform>();
        aDScore = adamObject.GetComponent<Adamo_Score>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {


            //t=s/v


            //can add rotate sprite in here if needed

            scriptRefrence.rizzGyatt = false;
            railGrind = true;

            //start coroutine to time
            // grind track checks if exit
            Debug.Log("enter2");

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalScore = comboScore * scriptRefrence.horizontalVelocity;
            aDScore.Score = aDScore.Score + finalScore;

            Debug.Log("combo" + comboScore);
            Debug.Log("final " + finalScore);
            Debug.Log("velocity" + scriptRefrence.horizontalVelocity);
            finalScore = 0;
            comboScore = 0;
            aDScore.comboCalc = true;
            railCollider.enabled = false;
            railGrind = false;
      
            scriptRefrence.rizzGyatt = true;

            StartCoroutine("destroyRail");
        }
    }

    void Update()
    {

        
        
        if (railGrind == true)
        {
           
            
            
            scriptRefrence.rb.velocity = new Vector2(scriptRefrence.horizontalVelocity, (scriptRefrence.horizontalVelocity * 0.70021f));
            if (Input.GetKeyDown(KeyCode.S))
            {
                starting = true;
                scriptRefrence.rizzGyatt = true;
                if (scriptRefrence.boosted == false)
                {
                    scriptRefrence.rb.AddForce(playerObject.transform.right * railJumpBurstRight, ForceMode2D.Impulse);
                    scriptRefrence.rb.AddForce(playerObject.transform.up * railJumpBurstUp, ForceMode2D.Impulse);
                    scriptRefrence.boosted = true;
                }
                //Debug.Log(comboScore);
                finalScore = (comboScore * scriptRefrence.horizontalVelocity) / 1.5f;
                aDScore.Score = aDScore.Score + finalScore;
                aDScore.comboCalc = true;
                //Debug.Log("combo" + comboScore);
                //Debug.Log("final " + finalScore);
                //Debug.Log("velocity" + scriptRefrence.horizontalVelocity);
                finalScore = 0;
                comboScore = 0;
                Destroy(railCollider);
            }
            
            if (starting == true && Input.GetKeyDown(KeyCode.A))
            {
                starting= false;
                pressA = true;
                
                comboScore += 1;

            }

            if (starting == true && Input.GetKeyDown(KeyCode.D))
            {
                starting = false;
                
                pressA = false;
                comboScore += 1;
            }
            if(starting == false && Input.GetKeyDown(KeyCode.A) && pressA == false)
            {
                
                pressA = true;
                comboScore += 1;
            }
            if (starting== false && Input.GetKeyDown(KeyCode.D) && pressA == true)
            {
                
                pressA = false;
                comboScore += 1;
            }

        }        
      
    }
    IEnumerator destroyRail()
    {
        
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);   
    }
  
    

}
   

   

