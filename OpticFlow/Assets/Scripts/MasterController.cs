using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;

public class MasterController : MonoBehaviour
{
    

    public int[,,] sectorCounter = new int[4,2,10]; // When initializing the conditions set these variables
    public int conditionKey; // Set in Printer
    public int probeKey; // Set in ProbeController
    public int sectorKey; // Set in ProbeController
    public float absoluteTilt; // Set in DialRotator
    public float probeAngle; // Set in ProbeController
    public int trialNumber; // Set in MasterController

    public float experimentTimer = 0;

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
        DontDestroyOnLoad(gameObject); // Makes object persist
        InitializeSectorCounter(); // Initializes the sector trial counter
        InitializeData(); // Initializes data format and file
        WriteHeader(); // Writes the header and creates the file
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
        experimentTimer += Time.deltaTime;
    }

    int varCount = 6;
    string[] volatileData = new string[6];

    void InitializeData() // Creates the header for the CSV file
    {
        volatileData[0] = "Trial Number";
        volatileData[1] = "Condition Index";
        volatileData[2] = "Probe Index";
        volatileData[3] = "Sector Index";
        volatileData[4] = "Absolute Tilt";
        volatileData[5] = "Probe Angle";
    }

    void WriteHeader() // Save header data as csv and create file
    {
        InitializeData(); // Initializes data file

        using (StreamWriter sw = File.AppendText(Application.dataPath + "SubjectData.csv")) // Uses the Streamwriter to write stuff
        {
            for(int i = 0; i < varCount; i++)
            {
                sw.Write(volatileData[i]);
                sw.Write(",");
            }

            sw.Write("\n");
            sw.Close();
        }

    }

    public void VolatileWriter()
    {
        
        volatileData[0] = ""+trialNumber;
        volatileData[1] = ""+conditionKey;
        volatileData[2] = ""+probeKey;
        volatileData[3] = ""+sectorKey;
        volatileData[4] = ""+absoluteTilt;
        volatileData[5] = ""+probeAngle;
        
        using (StreamWriter sw = File.AppendText(Application.dataPath + "SubjectData.csv")) // Uses the Streamwriter to write stuff
        {
            for(int i = 0; i < varCount; i++)
            {
                sw.Write(volatileData[i]);
                sw.Write(",");
            }

            sw.Write("\n");
            sw.Close();
        }

        trialNumber += 1;
    }
}