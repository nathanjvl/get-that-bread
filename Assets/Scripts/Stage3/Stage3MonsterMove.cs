using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3MonsterMove : MonoBehaviour
{

    public GameObject monster;
    public float obstacleSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        monster.GetComponent<Rigidbody2D>().velocity = Vector2.right * obstacleSpeed;
    }
}
