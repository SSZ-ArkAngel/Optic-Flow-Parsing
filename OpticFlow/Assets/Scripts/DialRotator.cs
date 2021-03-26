using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialRotator : MonoBehaviour
{
    Vector3 point; // We rotate around this point
    float rotationSpeed = 80; // How fast we rotate the dial in units per second
    public GameObject overlord;
    float timeOnDial = 0;
    float dialRotation;
    bool takeABreak;

    public int conditionKey;
    public int probeKey;
    public int sectorKey;

    bool enterPressed;
    void ConvertDialRotationToDegrees()
    {
        if(dialRotation < 0)
        {
            dialRotation = 360 + dialRotation;
        }
    }

    void ConvertProbeAngleToDegrees()
    {
        float probeAngle = overlord.GetComponent<MasterController>().probeAngle;
        probeAngle = probeAngle * (180/Mathf.PI);
        overlord.GetComponent<MasterController>().probeAngle = probeAngle;
    }
    
    // Start is called before the first frame update
    void Start()
    {

        enterPressed = false;

        overlord = GameObject.Find("Overlord");

        if(overlord.GetComponent<MasterController>().probeKey == 0) // Spawn at top
        {
            transform.localPosition = new Vector3 (0f, 2.8f, 0f);
        }

        if(overlord.GetComponent<MasterController>().probeKey == 1) // Spawn at bottom
        {
            transform.localPosition = new Vector3 (0f, -2.8f, 0f);
        }

        conditionKey = overlord.GetComponent<MasterController>().conditionKey;
        probeKey = overlord.GetComponent<MasterController>().probeKey;
        sectorKey = overlord.GetComponent<MasterController>().sectorKey;

        //point = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeOnDial += Time.deltaTime;

        // transform.RotateAround(point, Vector3.forward, rotationSpeed);
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
        {
            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed*Time.deltaTime);
            //dialRotation += rotationSpeed*Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
        {
            transform.RotateAround(transform.position, Vector3.back, rotationSpeed*Time.deltaTime);
            //dialRotation -= rotationSpeed*Time.deltaTime;
        }

        //if(Input.GetKey(KeyCode.Return))
        if(timeOnDial >= 6.0f || Input.GetKey(KeyCode.KeypadMinus))
        {
            //Vector3 paddleRotationTransform = transform.localRotation.eulerAngles;
            //overlord.GetComponent<MasterController>().absoluteTilt = paddleRotationTransform.z;
            SceneManager.LoadScene(4); // Loads blank screen
        }

        if(Input.GetKeyDown(KeyCode.Return) && !enterPressed)
        {
            enterPressed = true;
            dialRotation = transform.localEulerAngles.z; // Clockwise counts down from 360, so have to make it count up from 0 instead
            dialRotation = 360 - dialRotation; // for e.g if it's 330 this returns 360-330 = 30! If it's 45 it returns 360-45 = 315 which is correct!
            ConvertDialRotationToDegrees();
            ConvertProbeAngleToDegrees();
            overlord.GetComponent<MasterController>().sectorCounter[conditionKey,probeKey,sectorKey]++;;
            overlord.GetComponent<MasterController>().absoluteTilt = dialRotation;
            //Collect the data aka tilt
            overlord.GetComponent<MasterController>().reactionTime = timeOnDial;
            overlord.GetComponent<MasterController>().VolatileWriter();
        }

        // if(Input.GetKey(KeyCode.Space))
        // {
        //     SceneManager.LoadScene(1);
        // }

        // Quit if escape is hit
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
     
    }
}
