using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Player : MonoBehaviour
{
    public float movementInDelay = 0.5f;

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

    private int height;
    private float cooldown;

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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (height < 2 && cooldown > movementInDelay)
            {
                height++;
                cooldown = 0;
            } else
            {
                //y = -2 + up;
            }

            y = -2 + (height * 2);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (height > 0 && cooldown > movementInDelay)
            {
                height--;
                cooldown = 0;
            } else
            {
                //y = -2;
            }

            y = -2 + (height * 2);
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
            o.transform.localPosition = new Vector3(-10, -2 + ((int)Random.Range(0, 2.99f) * 2), 0);
            o.GetComponent<Rigidbody2D>().velocity = Vector2.right * obstacleSpeed;
        }

        cooldown += Time.deltaTime;
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
