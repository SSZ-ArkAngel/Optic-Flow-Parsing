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
    int maximumSectorCount = 10; //

    void SetprobePosition() // Either at top or bottom
    {
        // Spawn at X = 0, Z = 2.001, Y = ±0.7
        int randomSpawn = Random.Range(0, 2);

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

    void SetProbeVelocity() // Full 360° motion 
    {
        // float probeAngle = Random.Range (0f, 2*Mathf.PI); // Returns random value in degrees
        // probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
        // probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;

        int randomSector = Random.Range(0, 10); // Check to see if counter <= value, increment after doing stuff

        if(randomSector == 1)
        {
            if(overlord.GetComponent<MasterController>().counterSector1 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (0f, 0.2f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector1++;

        }
        if(randomSector == 2)
        {
            if(overlord.GetComponent<MasterController>().counterSector2 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (0.2f*Mathf.PI, 0.4f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector2++;            
        }
        if(randomSector == 3)
        {
            if(overlord.GetComponent<MasterController>().counterSector3 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (0.4f*Mathf.PI, 0.6f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector3++;                        
        }
        if(randomSector == 4)
        {
            if(overlord.GetComponent<MasterController>().counterSector4 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (0.6f*Mathf.PI, 0.8f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;  
            overlord.GetComponent<MasterController>().counterSector4++;                      
        }
        if(randomSector == 5)
        {
            if(overlord.GetComponent<MasterController>().counterSector5 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (0.8f*Mathf.PI, 1.0f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector5++;                        
        }
        if(randomSector == 6)
        {
            if(overlord.GetComponent<MasterController>().counterSector6 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (1.0f*Mathf.PI, 1.2f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector6++;                        
        }
        if(randomSector == 7)
        {
            if(overlord.GetComponent<MasterController>().counterSector7 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (1.2f*Mathf.PI, 1.4f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector7++;            
        }
        if(randomSector == 8)
        {
            if(overlord.GetComponent<MasterController>().counterSector8 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (1.4f*Mathf.PI, 1.6f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector8++;            
        }
        if(randomSector == 9)
        {
            if(overlord.GetComponent<MasterController>().counterSector9 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (1.6f*Mathf.PI, 1.8f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity; 
            overlord.GetComponent<MasterController>().counterSector9++;           
        }
        if(randomSector == 0)
        {
            if(overlord.GetComponent<MasterController>().counterSector0 > maximumSectorCount)
            {
                SetProbeVelocity();
            }
            float probeAngle = Random.Range (1.8f*Mathf.PI, 2f*Mathf.PI); // Returns random value in degrees
            probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
            probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
            overlord.GetComponent<MasterController>().counterSector0++;            
        }
        // If everything hit, then quit.
        if(overlord.GetComponent<MasterController>().counterSector1 > maximumSectorCount 
        && overlord.GetComponent<MasterController>().counterSector2 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector3 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector4 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector5 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector6 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector7 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector8 > maximumSectorCount
        && overlord.GetComponent<MasterController>().counterSector9 > maximumSectorCount 
        && overlord.GetComponent<MasterController>().counterSector0 > maximumSectorCount)
        {
            Application.Quit(); // Quits
        }
        

    }

    void AngleAssigner(float lowerAngle, float UpperAngle)
    {
        float probeAngle = Random.Range (lowerAngle*Mathf.PI, UpperAngle*Mathf.PI); // Returns random value in degrees
        probeXVelocity = Mathf.Cos(probeAngle)*probeVelocity;
        probeYVelocity = Mathf.Sin(probeAngle)*probeVelocity;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // ABOUT TO CALL THE COUNTERS!!!!!!!!!
        overlord = GameObject.Find("Overlord");
        
        SetProbeVelocity();
        SetprobePosition();
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
