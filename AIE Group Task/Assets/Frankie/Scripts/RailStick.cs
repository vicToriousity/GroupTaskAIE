using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RailStick : MonoBehaviour
{
    //basic stuff
    public Collider2D railCollider;
    public bool railGrind;
    public GameObject playerObject;

    //jump off rail
    public float railJumpBurstRight = 0f;
    public float railJumpBurstUp = 500f;


    //combo stuff
    private bool pressA;
    private bool starting = true;
    public int comboScore = 0;

    //maths
    //angle is 35
    //varC = 20;
    private float varA = 11.472f;
    private float varB = 16.383f;


    //scriptrefences
    public Move scriptRefrence;



    // Start is called before the first frame update
    void Start()
    {
        railCollider = GetComponent<Collider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        scriptRefrence = playerObject.GetComponent<Move>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {


            //t=s/v


            //can add rotate sprite in here if needed

            scriptRefrence.enabled = false;
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
            railCollider.enabled = false;
            railGrind = false;
            Debug.Log(comboScore);
            scriptRefrence.enabled = true;
        }
    }

    private void Update()
    {
        if (railGrind == true)
        {
           
            
            
            scriptRefrence.rb.velocity = new Vector2(varB, varA);
            if (Input.GetKeyDown(KeyCode.S))
            {
                starting = true;
                scriptRefrence.enabled = true;
                scriptRefrence.rb.AddForce(transform.right * railJumpBurstRight, ForceMode2D.Impulse);
                scriptRefrence.rb.AddForce(transform.up * railJumpBurstUp, ForceMode2D.Impulse);
                Debug.Log(comboScore);
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


}
   

   

