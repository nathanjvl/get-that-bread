using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOven : MonoBehaviour
{


    public Stage3Manager s3manager;

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
        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("Oven Took Damage!");
            Destroy(collision.gameObject);

            //ADD THINGS HERE FOR WHEN the oven takes damage
            s3manager.take_damage();
        }
    }

}
