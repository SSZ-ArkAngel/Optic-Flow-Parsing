using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    float delay = 1f;

    // Start is called before the first frame update
    
    void Fixation2Stimulus() // Switches from Fixation to Stimulus
    {
        // Wait for 1 second, then switch to the stimulus
        delay = 1f;
        StartCoroutine(LoadAfterLevelDelay(delay));
    }

    void Stimulus2Dial()
    {
        delay = 2f;
        StartCoroutine(LoadAfterLevelDelay(delay));
    }
    void Start()
    {
        // If fixation then use fixationswitch(), if stimulus using stimulusswitch(), if paddle use paddleswitch()
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Fixation2Stimulus();
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Stimulus2Dial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator LoadAfterLevelDelay (float delay)
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            yield return new WaitForSeconds(delay); // Starts a one second timer
            SceneManager.LoadScene(2); // Executes after one second timer
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            yield return new WaitForSeconds(delay); // Starts a one second timer
            SceneManager.LoadScene(3); // Executes after one second timer
        }
        
    }
}
