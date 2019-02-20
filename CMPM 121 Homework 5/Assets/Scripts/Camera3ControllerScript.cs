using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3ControllerScript : MonoBehaviour
{
    private Transform player;
    PlayerController _playerController;

    private Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player);
    }
}
