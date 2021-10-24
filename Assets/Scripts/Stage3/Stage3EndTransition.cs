using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3EndTransition : MonoBehaviour
{

    // This script contains the logic for when the Monster reaches the player
    // and transitions the scene

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "MonsterObjective")
        {
            Debug.Log("Will change scene now for button mash!");
        }
    }


}
