using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Manager : MonoBehaviour
{
    // This script will be used in order to keep track of the stage 1 progress and update the UI elements
    // Main implementation through count variables

    // The goal number for each ingredient
    public int milk_goal = 5;
    public int yeast_goal = 3;
    public int flour_goal = 7;
    public int life_amount = 3; // we can set this --> must match # of hearts

    // Counts for each type of ingredient collected
    public int milk_count = 0;
    public int yeast_count = 0;
    public int flour_count = 0;
    public int trash_count = 0;

    //images with the hearts / bread life
    public Image[] lives;
    //declares the text for the counts
    public Text[] counts;

    // The transition animator that is used for the fade in and out;
    public Animator transition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // display the counts on the UI
        if (milk_count <= milk_goal)
        {
            counts[0].text = (milk_goal - milk_count).ToString();
        }
        if (yeast_count <= yeast_goal)
        {
            counts[1].text = (yeast_goal - yeast_count).ToString();
        }
        if (flour_count <= flour_goal)
        {
            counts[2].text = (flour_goal - flour_count).ToString();
        }

        if (trash_count <= life_amount)
        {
            if (trash_count >= 1)
            {
                lives[2].enabled = false;
            }
            if (trash_count >= 2)
            {
                lives[1].enabled = false;
            }
            if (trash_count >= 3)
            {
                lives[0].enabled = false;
                // This is the game end sequence since player lost all lives
                StartCoroutine(TransitionGameOver());
            }
        }

        //Checking for win condition:
        if (milk_count >= milk_goal && yeast_count >= yeast_goal && flour_count >= flour_goal)
        {
            StartCoroutine(TransitionNextScene()); // start to transition to the art scene
        }
    }

//These will be used for coroutines in order to transition nicely to other scenes.
    IEnumerator TransitionNextScene(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1); // pauses for 1 second
        SceneManager.LoadScene("Stage3");
    }

    IEnumerator TransitionGameOver(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
