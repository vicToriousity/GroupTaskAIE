using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontal;
    private float jumppower = 16f;
    private float speedstart = 4f;
    private float speedlean = 9f;
    private bool isGrounded;

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
        if (Input.GetKey(KeyCode.D))
        {
            //2 different options depending on speed
            //transform.Translate(Vector2.right * Time.deltaTime * speedstart);
            rb.velocity = new Vector2(speedstart, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            Debug.Log("ye");
            rb.velocity = new Vector2(rb.velocity.x,jumppower);
        }
     
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

  
    
}
