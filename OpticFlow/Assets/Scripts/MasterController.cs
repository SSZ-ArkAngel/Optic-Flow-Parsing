using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour
{
    
    public int counterSector1 = 0;
    public int counterSector2 = 0;
    public int counterSector3 = 0;
    public int counterSector4 = 0;
    public int counterSector5 = 0;
    public int counterSector6 = 0;
    public int counterSector7 = 0;
    public int counterSector8 = 0;
    public int counterSector9 = 0;
    public int counterSector0 = 0;
    void Awake() // Awake is called when the object is created
    {
        DontDestroyOnLoad(gameObject);
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
}
