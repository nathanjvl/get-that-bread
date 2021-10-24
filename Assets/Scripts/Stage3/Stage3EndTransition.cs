using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3EndTransition : MonoBehaviour
{

    // This script contains the logic for when the Monster reaches the player
    // and transitions the scene

    public Stage3Manager s3manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Monster")
        {
            Debug.Log("Will change scene now for button mash!");
            s3manager.monsterReached = true;
        }
    }


}
