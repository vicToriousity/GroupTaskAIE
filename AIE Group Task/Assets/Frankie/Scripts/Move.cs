using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontal;
    private float jumppower = 4f;
    private float passivemovement = 6f;
    private float speedstart = 9f;
    private float speedlean = 4f;
    public float horizontalVelocity;
    private bool isGrounded;
    private bool oneSecond = true;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
        horizontalVelocity = rb.velocity.x;
       

        if (Input.GetKey(KeyCode.D))
        {
                    
            
            //transform.Translate(Vector2.right * Time.deltaTime * speedstart);
            rb.velocity = new Vector2(passivemovement, rb.velocity.y);  //this is setting velocity when it gets to it, invalidating  the rest
            if(horizontalVelocity <=15f && oneSecond==true)
            {
                Debug.Log("regular");
                StartCoroutine("Smallpush");
                StartCoroutine("Secondtimer");
            }
            else if (oneSecond==true) 
            {
                Debug.Log("speedlean");
                rb.velocity = new Vector2(speedlean, rb.velocity.y);
            }
           
            //rb.velocity replaces speed value, so need to find a way that works to create a baseline of speed hile adding AND NOT REPLACEING
            //speed when going back to the start of void update
            
        }

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //you slam ur penis imn the car door
    }


    IEnumerator Smallpush ()
    {
        Debug.Log("startcorotine");
        rb.velocity = new Vector2(speedstart, rb.velocity.y);
        yield return new WaitForSeconds(3);
        
        
    }

    IEnumerator Secondtimer ()
    {
        oneSecond = false;
        Debug.Log("timerstart");
        yield return new WaitForSeconds(3);
        oneSecond = true;
    }

   
}
