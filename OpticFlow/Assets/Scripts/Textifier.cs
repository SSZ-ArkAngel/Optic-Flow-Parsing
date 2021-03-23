using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textifier : MonoBehaviour
{
    public bool isTimer;
    public bool isTrialCounter;
    int trialCounter;
    float timer;
    public GameObject overlord;
    public Text dialText;

    // Start is called before the first frame update
    void Start()
    {
        overlord = GameObject.Find("Overlord");
        //timer = overlord.GetComponent<MasterController>().experimentTimer;
        trialCounter = overlord.GetComponent<MasterController>().trialNumber;

        if(isTrialCounter)
        {
            // Change the text to the trial number
            dialText.text = "Trial: " + trialCounter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimer)
        {
            timer = overlord.GetComponent<MasterController>().experimentTimer;
            // Change text to be the time of the trial
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);

            dialText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }       
    }
}
