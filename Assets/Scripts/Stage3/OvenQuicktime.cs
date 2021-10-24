using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementation of the quick time events for the oven
public class OvenQuicktime : MonoBehaviour
{
    public Animator ovenAnim;
    public Stage3Manager s3manager;

    public float window_time = 2f; // How long each window should be
    public float qt_timer = 2f; // should start at window_time and count down

    public float randomTime = 5f; // Varying time between quicktimes

    public float time_min = 5f;
    public float time_max = 10f;

    public bool active_quicktime = false;


    // Start is called before the first frame update
    void Start()
    {

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
    }

    //this is what happens when the timer runs out
    void qtTimerRunOut()
    {
        active_quicktime = false;
        ovenAnim.SetBool("is_Fire", false);
        s3manager.take_damage();
    }

    //this is what happens the player successfully clicks the button
    void qtSucceed()
    {
        active_quicktime = false;
        ovenAnim.SetBool("is_Fire", false);
    }

}
