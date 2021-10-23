using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //declares rigidbody
    private Rigidbody2D r;

    //declares speed
    public float speed;

    private GameObject stage1Manager;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();

        stage1Manager = GameObject.Find("Stage 1 Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //change velocity if player pushes certain button

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            r.velocity = new Vector2(speed * -1, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            r.velocity = new Vector2(speed, 0);
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
    }
}
