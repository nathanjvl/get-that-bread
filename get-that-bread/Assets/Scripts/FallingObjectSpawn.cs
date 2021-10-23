using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    //x axis range of object spawning
    public float range;

    public GameObject[] collectables;

    private float random;

    // Start is called before the first frame update
    void Start()
    {
        //sets random value
        random = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //if random timer is 0 spawn object

        if (random > 0)
        {
            random -= Time.deltaTime;
        } else
        {
            random = Random.Range(1, 5);
            Debug.Log("Spawned Object");
            GameObject currentCollectable = Instantiate(collectables[(int)Random.Range(0, 2.99f)]);
            currentCollectable.transform.localPosition = new Vector2(Random.Range(range * -1, range), 5);
        }
    }
}
