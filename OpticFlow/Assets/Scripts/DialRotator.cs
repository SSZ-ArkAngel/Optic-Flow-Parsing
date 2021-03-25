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

    void ConvertDialRotationToDegrees()
    {
        if(dialRotation < 0)
        {
            dialRotation = 360 + dialRotation;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        overlord = GameObject.Find("Overlord");
    }

    // Update is called once per frame
    void Update()
    {
        timeOnDial += Time.deltaTime;

        // transform.RotateAround(point, Vector3.forward, rotationSpeed);
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
        {
            transform.RotateAround(point, Vector3.forward, rotationSpeed*Time.deltaTime);
            dialRotation += rotationSpeed*Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
        {
            transform.RotateAround(point, Vector3.back, rotationSpeed*Time.deltaTime);
            dialRotation -= rotationSpeed*Time.deltaTime;
        }

        //if(Input.GetKey(KeyCode.Return))
        if(timeOnDial >= 6.0f || Input.GetKey(KeyCode.Return))
        {
            ConvertDialRotationToDegrees();
            //Vector3 paddleRotationTransform = transform.localRotation.eulerAngles;
            //overlord.GetComponent<MasterController>().absoluteTilt = paddleRotationTransform.z;
            overlord.GetComponent<MasterController>().absoluteTilt = dialRotation;
            //Collect the data aka tilt
            overlord.GetComponent<MasterController>().VolatileWriter();
            SceneManager.LoadScene(4); // Loads blank screen
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
