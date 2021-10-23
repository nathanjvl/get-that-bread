using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //declares rigidbody
    private Rigidbody2D r;

    //declares speed
    public float speed;

    //declares jump
    public float jump;

    //is the player on the floor
    private bool floor;

    private GameObject stage1Manager;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();

        floor = true;

        stage1Manager = GameObject.Find("Stage 1 Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //change velocity if player pushes certain button

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            r.velocity = new Vector2(speed * -1, r.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            r.velocity = new Vector2(speed, r.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && floor)
        {
            r.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Milk")
        {
            stage1Manager.GetComponent<Stage1Manager>().milk_count++;
        }

        if (collision.transform.tag == "Flour")
        {
            stage1Manager.GetComponent<Stage1Manager>().flour_count++;
        }

        if (collision.transform.tag == "Yeast")
        {
            stage1Manager.GetComponent<Stage1Manager>().yeast_count++;
        }

        if (collision.transform.tag == "Trash")
        {
            stage1Manager.GetComponent<Stage1Manager>().trash_count++;
        }

        if (collision.transform.name == "Floor")
        {
            floor = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Floor")
        {
            floor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Floor")
        {
            floor = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Floor")
        {
            floor = false;
        }
    }
}
