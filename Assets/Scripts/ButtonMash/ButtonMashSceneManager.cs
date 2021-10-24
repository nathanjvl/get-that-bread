using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The ButtonMash Scene Manager
public class ButtonMashSceneManager : MonoBehaviour
{

    // The transition animator that is used for the fade in and out;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        // THIS IS TEMPORARY SO WE CAN GET THROUGH ALL scenes
        StartCoroutine(TransitionToWin());
        // DELETE THE LINE ABOVE CALLING WIN
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Call when the player wins
    IEnumerator TransitionToWin(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1); // pauses for 1 second
        SceneManager.LoadScene("WinScreen");
    }

    //Call when the player fails
    IEnumerator TransitionGameOver(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }


}
