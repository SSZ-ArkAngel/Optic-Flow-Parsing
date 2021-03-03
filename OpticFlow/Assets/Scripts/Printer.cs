using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    
    public Transform opticFlow;
    public Vector3 flowPosition;

    int numFlow = 1000; // defines number of flow particles

    void randomNumberGenerator()
    {
        // Generating a random number between -5, 5
        flowPosition.x = Random.Range(-5f, 5f);
        flowPosition.y = Random.Range(-5f, 5f);
        flowPosition.z = Random.Range(-5f, 5f);

    }

    void Awake()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Transform flow = Instantiate(opticFlow);
        // flow.position = flowPosition;
        for(int i = 0; i < numFlow; i++)
        {
            randomNumberGenerator();
            Transform flow = Instantiate(opticFlow);
            flow.position = flowPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
