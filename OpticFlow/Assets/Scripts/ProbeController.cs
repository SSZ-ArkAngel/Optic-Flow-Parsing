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

    GameObject probeGameObject;
    GameObject mainCamera;

    void SetprobePosition() // Either at top or bottom
    {
        // Spawn at X = 0, Z = 2.001, Y = ±0.7
        int randomSpawn = Random.Range(0, 2);

        if(randomSpawn == 0) // Spawn at top
        {
            probePosition.x = 0f;
            probePosition.y = 0.7f; // Top
            probePosition.z = 2.001f; // Near Plane
        }

        if(randomSpawn == 1) // Spawn at bottom
        {
            probePosition.x = 0f;
            probePosition.y = -0.7f; // Bottom
            probePosition.z = 2.001f; // Near Plane
        }
    }

    void SetProbeVelocity() // Full 360° motion 
    {
        float probeAngle = Random.Range (0f, 2*Mathf.PI); // Returns random value in degrees
        probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
        probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
        

    }

    
    // Start is called before the first frame update
    void Start()
    {
        SetprobePosition();
        SetProbeVelocity();

        Transform probe = Instantiate(opticProbe);
        probe.position = probePosition;

        probeGameObject = GameObject.Find("Probe(Clone)");
        mainCamera = GameObject.Find("Main Camera");
        probeGameObject.transform.parent = mainCamera.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(probeXVelocity, probeYVelocity, 0.0f);
        Vector3 displacement = Time.deltaTime * velocity; // accounts for frame rates to make sure the object moves at the speed defined
        //transform.localPosition = transform.localPosition + displacement;
        probeGameObject.transform.localPosition += displacement;
    }
}
