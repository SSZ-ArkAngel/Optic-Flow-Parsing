using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour
{
    

    public int[,,] sectorCounter = new int[4,2,10]; // When initializing the conditions set these variables
    public int conditionKey;
    public int probeKey;
    public int sectorKey;

    void InitializeSectorCounter()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                for(int k = 0; k < 10; k++)
                {
                    sectorCounter[i,j,k] = 0;
                }
            }
        }
    }



    void Awake() // Awake is called when the object is created
    {
        DontDestroyOnLoad(gameObject);
        //InitializeSectorCounter();
    }

    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(Object);
        // SceneManager.LoadScene("Fixation");
        SceneManager.LoadScene(1); // Fixation is scene 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Writer() // Save data as csv
    {

    }
}
