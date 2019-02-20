using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManagerScript : MonoBehaviour
{
    public Camera roomOneCamera;
    public Camera roomTwoCamera;
    //public Camera roomThreeCamera;

    public Canvas WinScreen;
    public bool playerCanWin;

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.enabled = false;
        playerCanWin = false;
        roomOneCamera.enabled = true;
        roomTwoCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCanWin == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
            WinScreen.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Room1")
        {
            Debug.Log("InRoomOne");
            roomOneCamera.enabled = true;
            roomTwoCamera.enabled = false;
            //roomThreeCamera.enabled = false;
        }
        if (trigger.gameObject.tag == "Room2")
        {
            //Debug.Log("InRoomTwo");
            roomOneCamera.enabled = false;
            roomTwoCamera.enabled = true;
            //roomThreeCamera.enabled = false;

            playerCanWin = true;
            WinScreen.enabled = true;
        }
        //if (trigger.gameObject.tag == "Room3")
        //{
        //    Debug.Log("InRoomThree");
        //    roomOneCamera.enabled = false;
        //    roomTwoCamera.enabled = false;
        //    roomThreeCamera.enabled = true;
        //}
    }
}
