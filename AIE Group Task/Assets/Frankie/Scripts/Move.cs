using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class Move : MonoBehaviour
{
    public TMP_Text cooldownText;


    public float passivemovement = 6f;
    public float speedlean = 4f;
    public float leanLimit = 6f;
    public float upperLimit = 10f;
    public float jumppower = 4f;
    public GameObject GrindRail;
    public GameObject railSpawn;
    public float railCooldown = 1f;
    public GameObject cooldownObject;
    public float railCooldownText = 1f;

    private bool oneSecond = true;
    private bool cooldownRailSpawn = true;


    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float horizontalVelocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
  

    // Start is called before the first frame update
    void Start()
    {
        cooldownObject = GameObject.FindGameObjectWithTag("Cooldownfrankie");
        cooldownText = cooldownObject.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        

        horizontalVelocity = rb.velocity.x;
        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {

            rb.AddForce(transform.up * jumppower, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S) && !IsGrounded() && cooldownRailSpawn == true)
        {
            Vector3 railVector = railSpawn.transform.position;
            Instantiate(GrindRail, railVector, Quaternion.Euler(new Vector3(0, 0, 35)));
            StartCoroutine("CooldownRailTimer");
        }

        if (horizontalVelocity <= leanLimit && IsGrounded())
        {
            rb.AddForce(transform.right * passivemovement);
        }

        if (Input.GetKey(KeyCode.D) && IsGrounded())
        {


            //transform.Translate(Vector2.right * Time.deltaTime * speedstart);, in loving memory of liv roswarne
           

            if(horizontalVelocity <= upperLimit && oneSecond==true)
            {
                StartCoroutine("Smallpush");
                StartCoroutine("Secondtimer");
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
        
        rb.AddForce(transform.right * speedlean, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.75f);
        
        
    }

    IEnumerator Secondtimer ()
    {
        oneSecond = false;
        
        yield return new WaitForSeconds(0.75f);
        oneSecond = true;
    }

    IEnumerator CooldownRailTimer()
    {
        if (cooldownRailSpawn == true)
        {
            cooldownRailSpawn = false;
            cooldownText.text = ("Cooldown: " + ((railCooldownText -= Time.deltaTime).ToString("F2")));
            yield return new WaitForSeconds(railCooldown);
            cooldownRailSpawn = true;
        }
        
    }

}
