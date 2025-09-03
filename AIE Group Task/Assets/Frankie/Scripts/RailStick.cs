using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

public class RailStick : MonoBehaviour
{
    public Collider2D railCollider;
    public bool railGrind;
    private float accelTime;
    private bool pressS;

    //scriptrefences, merge atfter
    public Move scriptRefrence;
    public JumpAndRail jrScriptRefrence;


    // Start is called before the first frame update
    void Start()
    {
        railCollider = GetComponent<Collider2D>();
    }

    //this script
    //create new tag for the rail
    //if player tag enters collider, trigger global bool
    //when enters hitbox, follows path with speed told from the player movement script

    //also allow option for early exit that gives a slightly higher jump

    //also code in tricks


    //Player movemnt script
    //record velocity when bool swithces, it will be the speed as u are going while on it and when u leave it


    
    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {
           
            accelTime = 4.5f/scriptRefrence.horizontalVelocity;
            //t=s/v
            //replace 4.5 with wahtever the rail length ends up being
           

            //can add rotate sprite in here if needed
            scriptRefrence.transform.eulerAngles = Vector3.forward * 35;
            scriptRefrence.enabled = false;
            jrScriptRefrence.enabled = false;
            StartCoroutine("Timer");


            //start coroutine to time
            // grind track checks if exit
            Debug.Log("enter2");
            Destroy(railCollider);
        }
    }

    private void Update()
    {
        if (railGrind == true && pressS == false)
        {
            scriptRefrence.rb.velocity = new Vector2(scriptRefrence.horizontalVelocity, scriptRefrence.rb.velocity.y);
            // need calculation for speed
        }        
    }



    IEnumerator Timer ()
    {
        railGrind = true;
        pressS = false;
        //Debug.Log("timerstart");
        yield return new WaitForSeconds(accelTime);
        railGrind = false;
        pressS = true;
        scriptRefrence.enabled = true;
        jrScriptRefrence.enabled = true;
    }
}
    //void OnCollisionStay2D(Collision2D collision)
 //   {
    //    if (collision.gameObject.CompareTag("Player"))
 //       {
    //        Debug.Log("find player");
   //         if (Input.GetKeyDown(KeyCode.S))
   //         {
      //          Debug.Log("s");
      //          isCurrentlyColliding = false;
    //            Destroy(railCollider);
     //          scriptRefrence.rb.AddForce(scriptRefrence.transform.up * (jrScriptRefrence.jumppower+6f), ForceMode2D.Impulse);
      //          Debug.Log("s");
   //         }
    //    }
   // }
  

   

