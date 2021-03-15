using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeController : MonoBehaviour
{
    // 1. Define where to spawn probe
    // 2. Define where to move probe
    Vector3 probePosition;
    public Transform opticProbe;
    public float probeVelocity = 1f;

    float probeXVelocity;
    float probeYVelocity;
    float probeXOffset; // The X and Y offsets make sure the probes average position is the center
    float probeYOffset; // For now they can be derived from the velocities

    GameObject probeGameObject;
    GameObject mainCamera;

    float probeAngle; // Used to store the angle at which the probe moves
    int probeAngleDistribution; // Used to define the probability distribution for the possible angles

    void SetprobePosition() // Either at top or bottom
    {
        // Spawn at X = 0, Z = 2.001, Y = ±0.7
        int randomSpawn = Random.Range(0, 2);

        // We want the average position of the probe to be the coordinates listed before the additions below
        // The addition is an offset in the x and y components that are derived from the speed of the probe
        // It will pass through the center halfway through it's journey, which is 2 seconds long
        // the velocity is per second, therefore velocity * sine or cosine must be added to the probes offset

        if(tutorialStep == 1 || tutorialStep == 3 || tutorialStep == 5 || tutorialStep == 7) // Spawn at top
        {
            probePosition.x = 0f - probeXVelocity;
            probePosition.y = 0.7f - probeYVelocity; // Top
            probePosition.z = 2.001f; // Near Plane
        }

        if(tutorialStep == 2 || tutorialStep == 4 || tutorialStep == 6 || tutorialStep == 8) // Spawn at bottom
        {
            probePosition.x = 0f - probeXVelocity;
            probePosition.y = -0.7f - probeYVelocity; // Bottom
            probePosition.z = 2.001f; // Near Plane
        }
    }

    // void SetProbeVelocity() // Full 360° motion 
    // {
    //     float probeAngle = Random.Range (0f, 2*Mathf.PI); // Returns random value in radians
    //     probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
    //     probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
    // }

    void SetProbeVelocity() // Full 360° motion, with a higher distribution within a bowtie
    {
        //probeAngleDistribution = Random.Range(0, 3);
        probeAngleDistribution = 1;

        if(probeAngleDistribution <= 1) // 2/3 trials are within +/-
        {
            probeAngle = Random.Range (-0.5f, 0.5f); // Returns random value in degrees between ~ +/- 30
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
        }

        if(probeAngleDistribution == 2) // 2/3 trials are within +/-
        {
            probeAngle = Random.Range (0f, 2*Mathf.PI); // Returns random value in radians
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
        }

    }

    int tutorialStep;
    GameObject theOverlord;

    // Start is called before the first frame update
    void Start()
    {
        theOverlord = GameObject.Find("TheOverlord");
        tutorialStep = theOverlord.GetComponent<Overlord>().tutorialStep;
        
        SetProbeVelocity(); // Velocity must be set before position, as position depends on the velocity
        SetprobePosition();
        

        Transform probe = Instantiate(opticProbe);
        probe.position = probePosition;

        probeGameObject = GameObject.Find("Probe(Clone)");
        mainCamera = GameObject.Find("Main Camera");
        probeGameObject.transform.parent = mainCamera.transform;

        DebugLogger(); // Calls debug

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(probeXVelocity, probeYVelocity, 0.0f);
        Vector3 displacement = Time.deltaTime * velocity; // accounts for frame rates to make sure the object moves at the speed defined
        //transform.localPosition = transform.localPosition + displacement;
        probeGameObject.transform.localPosition += displacement;
    }

    void DebugLogger()
    {
        Debug.Log("Index of Probe Angle Selector " + probeAngleDistribution);
        Debug.Log("X-Vel: " + probeXVelocity);
        Debug.Log("Y-Vel: " + probeYVelocity);
    }

}
