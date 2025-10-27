using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailStick15 : MonoBehaviour
{
    //basic stuff
    public Collider2D railCollider;
    private bool railGrind;
    public GameObject playerObject;
    public GameObject adamObject;

    //jump off rail
    public float railJumpBurstRight = 3f;
    public float railJumpBurstUp = 8f;


    //combo stuff
    private bool pressA;
    private bool starting = true;
    private int comboScore = 0;
    private float finalScore = 0;

    //maths
    //angle is 0
    //varC = 20;



    //scriptrefences
    public Move scriptRefrence;
    public Adamo_Score aDScore;



    // Start is called before the first frame update
    void Start()
    {
        railCollider = GetComponent<Collider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        adamObject = GameObject.FindGameObjectWithTag("EventSyatumrizz");
        scriptRefrence = playerObject.GetComponent<Move>();
        aDScore = adamObject.GetComponent<Adamo_Score>();
        railCollider.isTrigger = true;
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


        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rail15"))
        {
            railCollider.isTrigger = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            // run math script foir score
            finalScore = (comboScore * scriptRefrence.horizontalVelocity) / 1.5f;
            aDScore.Score = aDScore.Score + finalScore;
            aDScore.comboCalc = true;
            //Debug.Log("combo" + comboScore);
            //Debug.Log("final " + finalScore);
            //Debug.Log("velocity" + scriptRefrence.horizontalVelocity);
            finalScore = 0;
            comboScore = 0;
            railCollider.isTrigger = true;
            railGrind = false;
            scriptRefrence.rizzGyatt = true;
            StartCoroutine("destroyRail");


        }
    }

    private void Update()
    {
        if (railGrind == true)
        {

           


            scriptRefrence.rb.velocity = new Vector2(scriptRefrence.horizontalVelocity, (scriptRefrence.horizontalVelocity * -0.26795f));
            if (Input.GetKeyDown(KeyCode.S))
            {
                starting = true;
                scriptRefrence.rizzGyatt = true;
                scriptRefrence.rb.AddForce(playerObject.transform.right * railJumpBurstRight, ForceMode2D.Impulse);
                scriptRefrence.rb.AddForce(playerObject.transform.up * railJumpBurstUp, ForceMode2D.Impulse);
                railCollider.isTrigger=true;
                railGrind = false;
                finalScore = (comboScore * scriptRefrence.horizontalVelocity) / 1.5f;
                aDScore.Score = aDScore.Score + finalScore;
                aDScore.comboCalc = true;
                //Debug.Log("combo" + comboScore);
                //Debug.Log("final " + finalScore);
                //Debug.Log("velocity" + scriptRefrence.horizontalVelocity);
                finalScore = 0;
                comboScore = 0;

            }

            if (starting == true && Input.GetKeyDown(KeyCode.A))
            {
                starting = false;
                pressA = true;

                comboScore += 1;

            }

            if (starting == true && Input.GetKeyDown(KeyCode.D))
            {
                starting = false;

                pressA = false;
                comboScore += 1;
            }
            if (starting == false && Input.GetKeyDown(KeyCode.A) && pressA == false)
            {

                pressA = true;
                comboScore += 1;
            }
            if (starting == false && Input.GetKeyDown(KeyCode.D) && pressA == true)
            {

                pressA = false;
                comboScore += 1;
            }

        }

    }
    
    IEnumerator destroyRail()
    {

        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
    
}
