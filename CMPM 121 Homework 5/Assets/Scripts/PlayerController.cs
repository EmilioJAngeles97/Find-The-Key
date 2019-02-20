using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // player movement
    private Rigidbody rb;
    public float speed;
    public float clockwise;
    public float counterClockwise;

    private Animator playerAnimations;

    private bool canPickUpKey;
    public bool playerHasKey;
    public GameObject key;
    public GameObject door;
    public ParticleSystem keyParticles;
    private Animation doorAnimation;

    // Player Receving and Throwing
    //public GameObject apple;
    //public GameObject hand;
    //public static int applesHolding;
    //public static bool applePickedUp;
    //public bool isColliding;
    //public Text applesHoldingScoreText;

    // Flashlight
    //public Light flashlight;
    //private bool flashlightOn;

    //// Camera Perspective
    //public Camera firstPerson;
    //public Camera thirdPerson;

    // Start is called before the first frame update
    void Start()
    {
        keyParticles.Stop();
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        clockwise = 100f;
        counterClockwise = -100f;

        playerAnimations = GetComponent<Animator>();
        playerAnimations.SetBool("Grounded", true);

        playerHasKey = false;
        canPickUpKey = false;

        doorAnimation = door.GetComponent<Animation>();

        //applesHolding = 0;
        //SetApplesHoldingText();

        //firstPerson.enabled = true;
        //thirdPerson.enabled = false;

        //applePickedUp = false;

        //flashlight.enabled = true;
        //flashlightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("flashlight on:" + flashlightOn);
        //Debug.Log("apples holding: " + applesHolding);
        //applePickedUp = false;
        //isColliding = false;

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            rb.position += transform.forward * Time.deltaTime * speed;
            playerAnimations.SetFloat("MoveSpeed", speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.position -= transform.forward * Time.deltaTime * speed;
            playerAnimations.SetFloat("MoveSpeed", speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.position -= transform.right * Time.deltaTime * speed;
            playerAnimations.SetFloat("MoveSpeed", speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.position += transform.right * Time.deltaTime * speed;
            playerAnimations.SetFloat("MoveSpeed", speed);
        }
        else
        {
            playerAnimations.SetFloat("MoveSpeed", 0);
        }

        // Rotation
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        }

        //// Throw Apple
        //if (Input.GetKeyDown(KeyCode.Space) && applesHolding > 0)
        //{
        //    applesHolding -= 1;
        //    SetApplesHoldingText();
        //    Instantiate(apple, hand.transform.position, hand.transform.rotation);
        //}

        //// Camera Perspective
        //if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        //{
        //    if (firstPerson.enabled == true)
        //    {
        //        firstPerson.enabled = false;
        //        thirdPerson.enabled = true;
        //    }
        //    else if (thirdPerson.enabled == true)
        //    {
        //        firstPerson.enabled = true;
        //        thirdPerson.enabled = false;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimations.SetTrigger("Pickup");
            if(canPickUpKey == true)
            {
                playerHasKey = true;
                keyParticles.Play();
                Destroy(key);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "KeyZone")
        {
            canPickUpKey = true;
        }

        if(collision.gameObject.tag == "DoorZone")
        {
            if(playerHasKey == true)
            {
                doorAnimation.Play();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "KeyZone")
        {
            canPickUpKey = false;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "AppleCollect")
    //    {
    //        Destroy(collision.gameObject);
    //        if (isColliding) return;
    //        applesHolding += 1;
    //        rb.freezeRotation = true;
    //        applePickedUp = true;
    //        isColliding = true;
    //        SetApplesHoldingText();
    //    }
    //}

    //void SetApplesHoldingText()
    //{
    //    applesHoldingScoreText.text = "Apples Holding: " + applesHolding.ToString();
    //}
}
