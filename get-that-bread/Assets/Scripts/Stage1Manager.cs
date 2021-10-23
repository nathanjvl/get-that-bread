using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    // This script will be used in order to keep track of the stage 1 progress and update the UI elements
    // Main implementation through count variables

    // these should include all 3 game object related to the health
    public GameObject[] hearts;

    // The goal number for each ingredient
    public int milk_goal;
    public int yeast_goal;
    public int flour_goal;
    public int life_amount = 3; // we can set this --> must match # of hearts

    // Counts for each type of ingredient collected
    public int milk_count = 0;
    public int yeast_count = 0;
    public int flour_count = 0;
    public int trash_count = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //

    }
}
