using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the manager for the first art scene
public class ArtTtoS1Manager : MonoBehaviour
{
    // Add references to animators controllers in order to
    // set their triggers and values so that we can have the camera
    // and other set pieces move around in time.

    private int currentScene;
    public float currentSceneMultiplier;

    private float timer;
    private float z_in;

    public GameObject c;

    // The transition animator that is used for the fade in and out;
    public Animator transition;


    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        z_in = -10;

        if (timer <= 0)
        {
            timer = 2;
            z_in = -10;
            currentScene++;
        }

        //StartCoroutine(ArtT2S1()); this will call the IEnumerator and start it
    }

    void Update()
    {
        timer -= Time.deltaTime;
        z_in += (Time.deltaTime)/4;

        if (timer <= 0)
        {
            timer = 2;
            z_in = -10;
            currentScene++;
        }

        //c.transform.position = Vector3.Lerp(c.transform.position, new Vector3(currentScene * currentSceneMultiplier, 0, -10), Time.deltaTime * 5);
        c.transform.position = Vector3.Lerp(c.transform.position, new Vector3(currentScene * currentSceneMultiplier, 0, z_in), Time.deltaTime * 5);

        if (currentScene >= 9)
        {
            StartCoroutine(ArtT2S1()); // this will call the IEnumerator and start it
        }


    }

    // This is where we can handle different timing to direct the camera
    IEnumerator ArtT2S1(){

        yield return new WaitForSeconds(1); // waiting for 2 seconds

        // THIS IS WHERE TO PUT HOW WE NAVIGATE THE ART AND ADD MORE PAUSES


        //End Sequence
        transition.SetTrigger("FadeOut"); // sets the variable to active the fade out transition
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage1"); // Will lead the first stage scene
    }

}
