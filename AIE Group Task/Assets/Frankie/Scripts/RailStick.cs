using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RailStick : MonoBehaviour
{
    public Collider2D railCollider;
    public bool isCurrentlyColliding;

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
            isCurrentlyColliding = true;
            //can add rotate sprite in here if needed
            scriptRefrence.transform.eulerAngles = Vector3.forward * 35;
            Debug.Log("enter");
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("find player");
            if (Input.GetKeyDown(KeyCode.S))
            {
                isCurrentlyColliding = false;
                Destroy(railCollider);
                scriptRefrence.rb.AddForce(scriptRefrence.transform.up * (jrScriptRefrence.jumppower+6f), ForceMode2D.Impulse);
                Debug.Log("s");
            }
        }
    }
   
}
