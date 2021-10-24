using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementation of the quick time events for the oven
public class OvenQuicktime : MonoBehaviour
{
    public Animator ovenAnim;
    public Stage3Manager s3manager;

    public float window_time = 2f;
    public float randomTime = 5f; // will be the time that counts down

    public float time_min = 5f;
    public float time_max = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (randomTime > 0)
        {
            randomTime -= Time.deltaTime;
        } else
        {
            // start quick time event
            randomTime = Random.Range(time_min, time_max);


        }


        if(Input.GetKeyDown(KeyCode.Space)){

        }
    }
}
