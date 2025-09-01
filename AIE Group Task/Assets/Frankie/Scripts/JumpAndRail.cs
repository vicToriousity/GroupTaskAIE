using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpAndRail : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;

    public float jumppower = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {

            rb.AddForce(transform.up * jumppower, ForceMode2D.Impulse);

        }
       // if (Input.GetKeyDown(KeyCode.S) && IsGrounded() == false)
       // {
            //
       // }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //you slam ur penis imn the car door
    }
}
