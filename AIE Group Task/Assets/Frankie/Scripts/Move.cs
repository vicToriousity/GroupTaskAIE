using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public TMP_Text cooldownText;

    public Animator animator;

    public float passivemovement = 9f;
    public float speedlean = 9f;
    public float leanLimit = 6f;
    public float upperLimit = 15f;
    public float jumppower = 12f;
    public GameObject GrindRail;
    public GameObject railSpawn;
    public float railCooldown = 1.75f;
    public float railCooldownforTimer = 1.75f;
    public GameObject cooldownObject;
    public bool rizzGyatt = true;
    public Image overlay;
    public GameObject overlayObject;

    public AudioSource skatesPush;
    public AudioSource skatesPassive;
    public AudioSource air;
    public AudioSource sonk;
   

    private bool oneSecond = true;
    public bool cooldownRailSpawn = true;
    private bool cooldownRailSpawnTimer = false;
    public bool boosted = false;



    public Rigidbody2D rb;
    [SerializeField] public float horizontalVelocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
  

    // Start is called before the first frame update
    void Start()
    {
        cooldownObject = GameObject.FindGameObjectWithTag("Cooldownfrankie");
        cooldownText = cooldownObject.GetComponent<TMP_Text>();
        
        overlayObject = GameObject.FindGameObjectWithTag("Overlayobject");
        overlay = overlayObject.GetComponent<Image>();
        overlay.fillAmount = 0;

        AudioSource[] audioS = GetComponents<AudioSource>();
        skatesPush = audioS[0];
        skatesPassive = audioS[1];
        air = audioS[2];
        sonk = audioS[3];
        air.Play();
        sonk.Play();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (IsGrounded())
        {
            boosted = false;
            skatesPassive.Play();
        }
        else
        {
            skatesPassive.Stop();
        }
        
        

        if (cooldownRailSpawn == false)
        {
            if (cooldownRailSpawnTimer == false)
            {
                StartCoroutine("cooldownDisp");
            }
            overlay.fillAmount = 0;

            overlay.fillAmount = railCooldownforTimer / railCooldown;

            cooldownText.text = ((railCooldownforTimer -= Time.deltaTime).ToString("F2"));
            //Debug.Log("dointthetuinh");
        }
        
        horizontalVelocity = rb.velocity.x;

        air.pitch = 0.5f + (horizontalVelocity/8);


        if (rizzGyatt == true)
        
        {
            
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

                if (horizontalVelocity <= upperLimit && oneSecond == true)
                {
                    StartCoroutine("Smallpush");
                    
                }

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
        oneSecond = false;
        skatesPush.Play();
        rb.AddForce(transform.right * speedlean, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.75f);
        oneSecond = true;


    }

   


    IEnumerator CooldownRailTimer()
    {
        if (cooldownRailSpawn == true)
        {
            cooldownRailSpawn = false;
            
            yield return new WaitForSeconds(railCooldown);
            cooldownRailSpawn = true;
        }
        
    }

    IEnumerator cooldownDisp()
    {

        cooldownRailSpawnTimer = true;
        
        yield return new WaitForSeconds(railCooldown);
        railCooldownforTimer = 1.75f;
        cooldownRailSpawnTimer = false;
        overlay.fillAmount = 0;

    }

}
