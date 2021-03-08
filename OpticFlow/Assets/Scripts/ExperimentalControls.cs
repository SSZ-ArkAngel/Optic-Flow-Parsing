using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentalControls : MonoBehaviour
{
    public float delay; // Should be 2 for stimulus, and 1 for fixation.
    public string nextScene; // Should be the name of the scene that is going to be switched to.

    // This script will provide controls for the experiment.
    // Hitting ESC will terminate the program.
    // After running for 2 seconds, it will transition to the next scene

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAfterLevelDelay(delay));
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
        SceneManager.LoadScene(nextScene);
    }
}
