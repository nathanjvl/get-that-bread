using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The ButtonMash Scene Manager
public class ButtonMashSceneManager : MonoBehaviour
{

    public int winCount;
    private int count;

    private float timer;
    private float currentTimer;

    // The transition animator that is used for the fade in and out;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        count = winCount / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;

            //temporary
            Debug.Log(count);
        }

        if (count >= winCount)
        {
            StartCoroutine(TransitionToWin());
        } else if (count >= winCount * 0.75f)
        {
            timer = 0.15f;
        } else if (count >= winCount * 0.5f)
        {
            timer = 0.2f;
        } else if (count >= winCount * 0.25f)
        {
            timer = 0.5f;
        }

        if (currentTimer < timer)
        {
            currentTimer += Time.deltaTime;
        } else
        {
            currentTimer = 0;
            count--;
        }
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
