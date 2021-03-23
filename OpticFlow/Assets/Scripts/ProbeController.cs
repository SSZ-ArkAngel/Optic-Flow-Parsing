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
    GameObject overlord; // Lowercase is in the script, Uppercase
    int maximumSectorCount = 6; //
    public int randomSector;
    public int conditionKey;
    public int probeKey;
    public int sectorKey;

    void SetprobePosition() // Either at top or bottom
    {
        // Spawn at X = 0, Z = 2.001, Y = ±0.7
        int randomSpawn = Random.Range(0, 2);
        overlord.GetComponent<MasterController>().probeKey = randomSpawn;

        if(randomSpawn == 0) // Spawn at top
        {
            probePosition.x = 0f - probeXVelocity;
            probePosition.y = 0.7f - probeYVelocity; // Top
            probePosition.z = 2.001f; // Near Plane
        }

        if(randomSpawn == 1) // Spawn at bottom
        {
            probePosition.x = 0f - probeXVelocity;
            probePosition.y = -0.7f - probeYVelocity; // Bottom
            probePosition.z = 2.001f; // Near Plane

        }
    }

    void SectorSelector()
    {
        randomSector = Random.Range(0,10);
        overlord.GetComponent<MasterController>().sectorKey = randomSector;
        if(overlord.GetComponent<MasterController>().sectorCounter[conditionKey, probeKey, sectorKey] <= maximumSectorCount)
        {
            SetProbeVelocity();
        }
        if(overlord.GetComponent<MasterController>().sectorCounter[conditionKey, probeKey, sectorKey] > maximumSectorCount)
        {
            SectorSelector();
        }
    }

    void SetProbeVelocity() // Full 360° motion 
    {
        if(randomSector == 0)
        {
            SetSectorAngle(0f, 0.2f);
        }

        if(randomSector == 1)
        {
            SetSectorAngle(0.2f, 0.4f);
        }

        if(randomSector == 2)
        {
            SetSectorAngle(0.4f, 0.6f);
        }
        if(randomSector == 3)
        {
            SetSectorAngle(0.6f, 0.8f);
        } 
        if(randomSector == 4)
        {
            SetSectorAngle(0.8f, 1.0f);
        }

        if(randomSector == 5)
        {
            SetSectorAngle(1.0f, 1.2f);
        }

        if(randomSector == 6)
        {
            SetSectorAngle(1.2f, 1.4f);
        }

        if(randomSector == 7)
        {
            SetSectorAngle(1.4f, 1.6f);
        }

        if(randomSector == 8)
        {
            SetSectorAngle(1.6f, 1.8f);
        }

        if(randomSector == 9)
        {
            SetSectorAngle(1.8f, 2.0f);
        }      
    }

    void SetSectorAngle(float minimumAngle, float maximumAngle)
    {
        float probeAngle = Random.Range(minimumAngle*Mathf.PI, maximumAngle*Mathf.PI);
        probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
        probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
        overlord.GetComponent<MasterController>().probeAngle = probeAngle;
    }

    // void AngleAssigner(float lowerAngle, float UpperAngle)
    // {
    //     float probeAngle = Random.Range (lowerAngle*Mathf.PI, UpperAngle*Mathf.PI); // Returns random value in degrees
    //     probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
    //     probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        // ABOUT TO CALL THE COUNTERS!!!!!!!!!
        overlord = GameObject.Find("Overlord");
        conditionKey = overlord.GetComponent<MasterController>().conditionKey;
        probeKey = overlord.GetComponent<MasterController>().probeKey;
        sectorKey = overlord.GetComponent<MasterController>().sectorKey;


        SectorSelector();
        SetprobePosition();
        
        // SetProbeVelocity();
        // SetprobePosition();
        // SetProbeVelocity();

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
