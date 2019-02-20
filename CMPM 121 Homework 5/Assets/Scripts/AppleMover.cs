using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMover : MonoBehaviour
{
    public float appleSpeed;
    public float appleGravity;
    public float appleTimeLimit;

    // Start is called before the first frame update
    void Start()
    {
        appleSpeed = 20f;
        appleGravity = 3f;
        appleTimeLimit = 3f;
        StartCoroutine(DestroyApple());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * appleSpeed;
        transform.position -= transform.up * Time.deltaTime * appleGravity;
    }

    IEnumerator DestroyApple()
    {
        yield return new WaitForSeconds(appleTimeLimit);
        Destroy(this.gameObject);
    }
}
