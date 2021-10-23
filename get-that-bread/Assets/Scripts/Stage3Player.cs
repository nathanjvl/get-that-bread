using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Player : MonoBehaviour
{
    private float y;
    public float up;

    // Start is called before the first frame update
    void Start()
    {
        y = -2;
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
    }
}
