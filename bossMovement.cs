using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public Rigidbody rg;
    Vector3 movement;
    bool dead = false;

    public float speed = 10;
    public float bounds = 10;
    public bool tracker;
    Transform player;

    // Start is called before the first frame update
    /* enemy move when the player inside the range.
    IEnumerator Start()
    {

        while((transform.position.z - player.position.z) > 15)
        {
            yield return null;
        }
        player = GameObject.FindWithTag("Player").transform;
        if(tracker) StartCoroutine(Tracker());
        else  StartCoroutine(LeftRight());
    }
    */
    void Start()
    {
        StartCoroutine(LeftRight());
    }

    IEnumerator LeftRight()
    {
        while (!dead)
        {
            while (transform.position.x > -bounds)
            {
                movement.x = -speed;
                rg.velocity = movement;
                yield return null;
            }

            while (transform.position.x < bounds)
            {
                movement.x = speed;
                rg.velocity = movement;
                yield return null;
            }
            yield return null;

        }
    }
    
    
}
