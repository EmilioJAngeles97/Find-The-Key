using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplesCollectedScore : MonoBehaviour
{
    public Text applesCollectedScoreText;
    public int applesCollectedScore;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        SetApplesCollectedText();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        if (Tent.appleReceived == true)
        {
            applesCollectedScore = Tent.applesCollected;
            SetApplesCollectedText();
        }
    }

    void SetApplesCollectedText()
    {
        applesCollectedScoreText.text = "Apples Collected: " + applesCollectedScore.ToString();
    }
}
