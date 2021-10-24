using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is meant to be added to buttons in order to access the
// functions within this script.


public class ButtonHandler_SceneTransitions : MonoBehaviour
{
    //Changes the scene to the title screen
    public void TransitionTitleScreen(){
        Debug.Log("Transitioning to Title Screen");
        SceneManager.LoadScene("Title Screen");
    }

    //Changes the scene to the Art Scene between Title and Stage 1
    public void TransitionArt1(){
        Debug.Log("Transitioning to Art1");
        SceneManager.LoadScene("ArtTitleToStage1");
    }

}
