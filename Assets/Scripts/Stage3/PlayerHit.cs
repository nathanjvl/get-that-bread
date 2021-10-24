using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Animator playerAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("Punch!");

            //ADD THINGS HERE FOR WHEN the player punches
            playerAnim.SetTrigger("Punch");

        }
    }
}
