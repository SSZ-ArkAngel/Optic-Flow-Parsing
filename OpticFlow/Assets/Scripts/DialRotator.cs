using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialRotator : MonoBehaviour
{
    Vector3 point; // We rotate around this point
    float rotationSpeed = 80; // How fast we rotate the dial in units per second


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // transform.RotateAround(point, Vector3.forward, rotationSpeed);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(point, Vector3.forward, rotationSpeed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(point, Vector3.back, rotationSpeed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Return))
        {
            //Collect the data aka tilt
            SceneManager.LoadScene(1);
        }
     
    }
}
