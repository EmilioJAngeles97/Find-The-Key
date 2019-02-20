using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    public static bool appleReceived;
    public static int applesCollected;
    public bool collisionDetected;

    // Start is called before the first frame update
    void Start()
    {
        applesCollected = 0;
        appleReceived = false;
    }

    // Update is called once per frame
    void Update()
    {
        appleReceived = false;
        collisionDetected = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AppleThrown")
        {
            Destroy(collision.gameObject);
            if (collisionDetected) return;
            applesCollected += 1;
            appleReceived = true;
            collisionDetected = true;
        }
    }
}
