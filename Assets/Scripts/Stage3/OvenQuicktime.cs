using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implementation of the quick time events for the oven
public class OvenQuicktime : MonoBehaviour
{
    public Animator ovenAnim;
    public Stage3Manager s3manager;

    public float window_time = 2f; // How long each window should be
    public float qt_timer = 3f; // should start at window_time and count down

    public float randomTime = 5f; // Varying time between quicktimes

    public float time_min = 2f;
    public float time_max = 7f;

    public bool active_quicktime = false;

    // The UI element for prompting the user
    public Image qt_prompt; // the whole toast text
    public Text qt_prompt_text; // shows press G
    public Text qt_prompt_time; // shows: 3... 2... 1...


    // Start is called before the first frame update
    void Start()
    {
        qtWarningHide();
    }

    // Update is called once per frame
    void Update()
    {

        if (active_quicktime == false)
        {
            // No active quicktime // setting the time to see when the next one
            // should activate
            if (randomTime > 0)
            {
                randomTime -= Time.deltaTime;
            } else
            {
                // start quick time event
                Debug.Log("Quicktime is starting");
                randomTime = Random.Range(time_min, time_max);
                qtStart();

            }
        } else if (active_quicktime && Input.GetKeyDown(KeyCode.G))
        {
            //This means they pressed the button correctly
            qtSucceed();

        } else
        {
            // This case means there is an active quicktime;
            if (qt_timer > 0)
            {
                //setting the qt_prompt_time
                if (qt_timer >= 2)
                {
                    qt_prompt_time.text = "3...";
                } else if (qt_timer >=1)
                {
                    qt_prompt_time.text  = "2...";
                } else
                {
                    qt_prompt_time.text = "1...";
                }
                qt_timer -= Time.deltaTime;
            } else
            {
                // This means the timer hit 0;
                qtTimerRunOut();
            }
        }
    }

    //a quicktime event has start
    void qtStart()
    {
        qt_timer = window_time;
        active_quicktime = true;
        ovenAnim.SetBool("is_Fire", true);

        qt_prompt_time.text = "3...";
        qtWarningShow();

    }

    //this is what happens when the timer runs out
    void qtTimerRunOut()
    {
        qtWarningHide();

        active_quicktime = false;
        ovenAnim.SetBool("is_Fire", false);
        s3manager.take_damage();
    }

    //this is what happens the player successfully clicks the button
    void qtSucceed()
    {
        qtWarningHide();

        active_quicktime = false;
        ovenAnim.SetBool("is_Fire", false);
    }

    void qtWarningShow(){
        qt_prompt.enabled = true;
        qt_prompt_text.enabled = true;
        qt_prompt_time.enabled = true;
    }

    void qtWarningHide(){
        qt_prompt.enabled = false;
        qt_prompt_text.enabled = false;
        qt_prompt_time.enabled = false;
    }

}
