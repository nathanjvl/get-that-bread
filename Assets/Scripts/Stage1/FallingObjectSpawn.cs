using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    //x axis range of object spawning

    public float range;

    public GameObject[] collectables;

    private float random;

    public float scale;

    // this is set to true but can be false to stop spawning
    public bool can_spawn = true;

    public Stage1Manager s1manager;

    // Start is called before the first frame update
    void Start()
    {
        //sets random value
        random = Random.Range(1, 5);

        if (scale <= 0)
        {
            scale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if random timer is 0 spawn object
        if(can_spawn)
        {
            if (random > 0)
            {
                random -= Time.deltaTime;
            } else
            {
                random = Random.Range(1, 5);
                Debug.Log("Spawned Object");

                int rand_generate_item = (int)Random.Range(0, 4.99f);

                //checking if it's all collected, if yes, then set to trash
                // 0: flour,  1: milk, 2: yeast, 3:trash, 4: trash

                if (rand_generate_item == 1 && s1manager.milk_count >= s1manager.milk_goal)
                {
                    rand_generate_item = 3;
                }
                if (rand_generate_item == 2 && s1manager.yeast_count >= s1manager.yeast_goal)
                {
                    rand_generate_item = 3;
                }
                if (rand_generate_item == 0 && s1manager.flour_count >= s1manager.flour_goal)
                {
                    rand_generate_item = 3;
                }

                //int rand_generate_item = (int)Random.Range(0, 4.99f);
                GameObject currentCollectable = Instantiate(collectables[rand_generate_item]);
                //GameObject currentCollectable = Instantiate(collectables[(int)Random.Range(0, 4.99f)]);
                currentCollectable.transform.localPosition = new Vector2(Random.Range(range * -1, range), 10);
                currentCollectable.transform.localScale = Vector3.one * scale;
            }
        }

    }
}
