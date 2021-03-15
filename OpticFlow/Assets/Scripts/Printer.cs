using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    
    public Transform opticFlow; // Allows us to define what prefab is used for optic flow
    Vector3 flowPosition; // Used to initialize a random position for each optic flow particle

    int particleDensity = 3000; // Defines number of ideal number of flow particles
    int actualDensity; // Actual number of flow particles used

    void FullConditionGenerator() // Generates full condition
    {
        actualDensity = particleDensity;
        
        for(int i = 0; i < actualDensity; i++)
        {
            flowPosition.x = Random.Range(-10f, 10f);
            flowPosition.y = Random.Range(-10f, 10f); // All possible y-values are used
            flowPosition.z = Random.Range(0f, 50f);

            Transform flow = Instantiate(opticFlow);
            flow.position = flowPosition;
        } 
    }

    void TopConditionGenerator() // Generates top condition
    {
        
        actualDensity = particleDensity/2;

        for(int i = 0; i < actualDensity; i++)
        {
            flowPosition.x = Random.Range(-10f, 10f);
            flowPosition.y = Random.Range(0f, 10f); // Only upper Y-values are used
            flowPosition.z = Random.Range(0f, 50f);

            Transform flow = Instantiate(opticFlow);
            flow.position = flowPosition;
        }      
    }

    void BottomConditionGenerator() // Generates bottom condition
    {
        actualDensity = particleDensity/2;

        for(int i = 0; i < actualDensity; i++)
        {
            flowPosition.x = Random.Range(-10f, 10f);
            flowPosition.y = Random.Range(-10f, 0f); // Only bottom Y-values are used
            flowPosition.z = Random.Range(0f, 50f);

            Transform flow = Instantiate(opticFlow);
            flow.position = flowPosition;
        }
        
    }

    void ControlConditionGenerator()
    {
        // :p
    }

    void Awake()
    {

    }
    
    int tutorialStep;
    GameObject theOverlord;

    // Start is called before the first frame update
    void Start()
    {
        theOverlord = GameObject.Find("TheOverlord");
        tutorialStep = theOverlord.GetComponent<Overlord>().tutorialStep;
        
        int condition = Random.Range(0, 4); // Create a RNG to choose between 0, 1, and 2. 0 = full, 1 = top, 2 = bottom

            // Conditional branch to choose which generator to use
            if(tutorialStep == 1 || tutorialStep == 2)
            {
                FullConditionGenerator();
            }
            if(tutorialStep == 3 || tutorialStep == 6)
            {
                TopConditionGenerator();
            }
            if(tutorialStep == 4 || tutorialStep == 5)
            {
                BottomConditionGenerator();
            }
            if(tutorialStep == 7 || tutorialStep == 8)
            {
                ControlConditionGenerator();
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
