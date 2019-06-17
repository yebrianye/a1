using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 15;

        Destroy(gameObject, 5);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("hit");
        Destroy(gameObject);
    }
}

