using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementation of the quick time events for the oven
public class OvenQuicktime : MonoBehaviour
{
    public Animator ovenAnim;
    public Stage3Manager s3manager;

    public float window_time = 2f;
    public float timer; // will be the time that counts down 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

        }
    }
}
