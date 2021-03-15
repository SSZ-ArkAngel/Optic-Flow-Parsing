using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlord : MonoBehaviour
{
    
    public int tutorialStep = 1; // Stores the index for the tutorial step
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
       SceneManager.LoadScene("Walkthrough"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
