using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Player : MonoBehaviour
{
    private float y;
    public float up;

    public GameObject obstacle;

    private float obstacleTime;
    private float randomTime;

    public float obstacleSpeed;
    private bool hit;

    public GameObject hitbox;

    private int health;
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        y = -2;
        obstacleTime = 5;

        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //player up and down

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

        //checks to make sure y position is within the range

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (y < -2 + up)
            {
                y += Time.deltaTime * 2;
            } else
            {
                y = -2 + up;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (y > -2)
            {
                y -= Time.deltaTime * 2;
            } else
            {
                y = -2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hit = true;
            hitbox.SetActive(true);

            delay = 0.1f;
        } else
        {
            delay -= Time.deltaTime;

            if (delay < 0)
            {
                hit = false;
                hitbox.SetActive(false);
            }

            
        }

        //subtract time from timers

        if (obstacleTime > 0.1f)
        {
            obstacleTime -= Time.deltaTime / 15;
        } else
        {
            obstacleTime = 0.1f;
        }

        

        if (randomTime > 0)
        {
            randomTime -= Time.deltaTime;
        } else
        {
            //spawn obstacle
            randomTime = Random.Range(obstacleTime, obstacleTime * 2);
            GameObject o = Instantiate(obstacle);
            o.transform.localPosition = new Vector3(-10, (int)(-2 + Random.Range(-0.99f, up - 0.01f)), 0);
            o.GetComponent<Rigidbody2D>().velocity = Vector2.right * obstacleSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided");

            if (hit)
            {
                //sound effect
            } else
            {
                LoseHealth();
            }


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle" && hit)
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided");
        }
    }

    public void LoseHealth()
    {
        health -= 1;
        Debug.Log(health);
    }
}
