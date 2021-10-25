using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the manager for the Second art scene
public class ArtS1toS3Manager : MonoBehaviour
{
    // Add references to animators controllers in order to
    // set their triggers and values so that we can have the camera
    // and other set pieces move around in time.

    private int currentScene;
    public float currentSceneMultiplier;

    private float timer;

    public GameObject c;

    // The transition animator that is used for the fade in and out;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2;

        if (timer <= 0)
        {
            timer = 2;
            currentScene++;
        }

        //StartCoroutine(ArtT2S1()); this will call the IEnumerator and start it
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 2;
            currentScene++;
        }

        c.transform.position = Vector3.Lerp(c.transform.position, new Vector3(currentScene * currentSceneMultiplier, 0, -10), Time.deltaTime * 5);

        if (currentScene >= 2)
        {
            StartCoroutine(ArtS12S3()); // this will call the IEnumerator and start it
        }

    }


    // This is where we can handle different timing to direct the camera
    IEnumerator ArtS12S3(){

        //End Sequence
        transition.SetTrigger("FadeOut"); // sets the variable to active the fade out transition
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage3"); // Will lead the first stage scene
    }
}
