using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentalControls : MonoBehaviour
{
    public float delay; // Should be 2 for stimulus, and 1 for fixation.
    public string nextScene; // Should be the name of the scene that is going to be switched to.

    public GameObject theOverlord;
    int tutorialStep;

    // This script will provide controls for the experiment.
    // Hitting ESC will terminate the program.
    // After running for 2 seconds, it will transition to the next scene

    // Start is called before the first frame update
    void Start()
    {
        theOverlord = GameObject.Find("TheOverlord");
        tutorialStep = theOverlord.GetComponent<Overlord>().tutorialStep;
        Debug.Log(tutorialStep);
        StartCoroutine(LoadAfterLevelDelay(delay));

        // Set dynamic timer for the walkthrough
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(tutorialStep%2 == 1)
            {
                delay = 5f;
            }
            if(tutorialStep%2 ==0)
            {
                delay = 2.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Read input from the keyboard and check for ESC to quit
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator LoadAfterLevelDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //tutorialStep += 1;
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene("Stimulus");
        }
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            tutorialStep++;
            theOverlord.GetComponent<Overlord>().tutorialStep = tutorialStep;
            SceneManager.LoadScene("Walkthrough");
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(nextScene);
        }
        if(tutorialStep >= 9 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Application.Quit();
        }
    }
}
