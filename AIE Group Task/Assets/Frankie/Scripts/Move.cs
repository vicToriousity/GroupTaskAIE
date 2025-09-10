using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    public float passivemovement = 6f;
    public float speedstart = 9f;
    public float speedlean = 4f;
    public float leanLimit = 6f;
    public float upperLimit = 10f;
    public float jumppower = 4f;

    private bool oneSecond = true;

    
      
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float horizontalVelocity;
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
        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {

            rb.AddForce(transform.up * jumppower, ForceMode2D.Impulse);

        }

        if (Input.GetKey(KeyCode.D) && IsGrounded())
        {


            //transform.Translate(Vector2.right * Time.deltaTime * speedstart);
            if (horizontalVelocity < passivemovement) 
            {
                rb.AddForce(transform.right * passivemovement);  
                //Debug.Log(horizontalVelocity);
            }

            if(horizontalVelocity <=leanLimit && oneSecond==true)
            {
                
                StartCoroutine("Smallpush");
                StartCoroutine("Secondtimer");
            }
            else if (horizontalVelocity <= upperLimit && oneSecond ==true) 
            {
                //Debug.Log("speedlean");
                rb.AddForce(transform.right * speedlean);
            }
           
           
            
        }

        

    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //you slam ur penis imn the car door
    }

    IEnumerator Smallpush ()
    {
        //Debug.Log("startcorotine");
        rb.AddForce(transform.right * speedstart, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        
        
    }

    IEnumerator Secondtimer ()
    {
        oneSecond = false;
        //Debug.Log("timerstart");
        yield return new WaitForSeconds(1);
        oneSecond = true;
    }

   
}
