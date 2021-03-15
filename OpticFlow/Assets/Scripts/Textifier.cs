using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Textifier : MonoBehaviour
{
    
    int tutorialStep;
    GameObject theOverlord; 
    // float delay = 5.0f;
    float timer = 0f;
    public Text walkthrough;

    /* 
    Alright let's start with a basic overview of each step
    Step 1: Show the optic flow field
    Step 2: Full condition with probe on top
    Step 3: Full condition with probe on bottom
    Step 4: Same condition with probe on top
    Step 5: Same condition with probe on bottom
    Step 6: Opposite condition with probe on top
    Step 7: Opposite condition with probe on bottom
    Step 8: Control condition with probe on top
    Step 9: Control condition with probe on top
    Step 10: The End
     */

    // Start is called before the first frame update
    void Start()
    {

        theOverlord = GameObject.Find("TheOverlord");
        tutorialStep = theOverlord.GetComponent<Overlord>().tutorialStep;
        //LoadAfterLevelDelay(delay);

        if(tutorialStep == 0)
        {
            // First let's check out what our optic flow field looks like!
            walkthrough.text = "First let's check out what our optic flow field looks like!";
        }
        if(tutorialStep == 1)
        {
            // There first set of conditions are the full conditions. First the probe will be on the top.
            walkthrough.text = "There first set of conditions are the full conditions. First the probe will be on the top.";
        }
        if(tutorialStep == 2)
        {
            // Then the probe will be on the bottom.
            walkthrough.text = "Then the probe will be on the bottom.";
        }
        if(tutorialStep == 3)
        {
            // The second set of conditions are the same conditions. First the probe will be on the top.
            walkthrough.text = "The second set of conditions are the same conditions. First the probe will be on the top.";
        }
        if(tutorialStep == 4)
        {
            // Then the probe will be on the bottom.
            walkthrough.text = "Then the probe will be on the bottom.";
        }
        if(tutorialStep == 5)
        {
            // The third set of conditions are the opposite conditions. First the probe will be on the top.
            walkthrough.text = "The third set of conditions are the opposite conditions. First the probe will be on the top.";
        }
        if(tutorialStep == 6)
        {
            // Then the probe will be on the the bottom.
            walkthrough.text = "Then the probe will be on the the bottom."  ; 
        }
        if(tutorialStep == 7)
        {
            // The fourth and final set of conditions are the control conditions. First the probe will be on the top.
            walkthrough.text = "The fourth and final set of conditions are the control conditions. First the probe will be on the top.";
        }
        if(tutorialStep == 8)
        {
            // Then the probe will be on the bottom.
            walkthrough.text = "Then the probe will be on the bottom.";
        }
        if(tutorialStep == 9)
        {
            // That's a rundown of our experimental conditions! Four different sets: The Full, Same, Opposite, and Control sets. And within each set the probe is either on the top or the bottom.
            walkthrough.text = "That's a rundown of our experimental conditions! Four different sets: The Full, Same, Opposite, and Control sets. And within each set the probe is either on the top or the bottom.";
        }
        if(tutorialStep >= 10)
        {
            // That's a rundown of our experimental conditions! Four different sets: The Full, Same, Opposite, and Control sets. And within each set the probe is either on the top or the bottom.
            walkthrough.text = "Hmm... If you're seeing this, my code to kill the program didn't work. You can close the tab now! Or leave it open... hopefully this program won't gain self-awareness if you leave it alone";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        // Debug.Log("Timer: " + timer);
    }

    // IEnumerator LoadAfterLevelDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     SceneManager.LoadScene("Fixation");
    // }

}
