using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UIElements;

public class RailStick : MonoBehaviour
{
    public Collider2D railCollider;
    public bool railGrind;
   
    private bool pressS;

    //maths
    //angle is 35
    public float varC = 20;
    private float varA = 11.472f;
    private float varB = 16.383f;
    private float accelTime;

    //scriptrefences, merge atfter
    public Move scriptRefrence;
    


    // Start is called before the first frame update
    void Start()
    {
        railCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D (Collision2D collision)
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
            pressS = true;
        }
    }

    private void Update()
    {
        if (railGrind == true && pressS == false)
        {
           
            //scriptRefrence.rb.velocity = new Vector2(scriptRefrence.horizontalVelocity, scriptRefrence.rb.velocity.y);
            
            
            scriptRefrence.rb.velocity = new Vector2(varB, varA);
            // need calculation for speed

        }        
    }



    IEnumerator Timer ()
    {
        railGrind = true;
        pressS = false;
        Debug.Log("Start time");
        yield return new WaitForSeconds(accelTime);
        railGrind = false;
        pressS = true;
        scriptRefrence.enabled = true;
        Debug.Log("End time");

    }
}
   

   

