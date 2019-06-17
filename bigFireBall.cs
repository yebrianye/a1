using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigFireBall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 30;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("hughit");
    }
    void hit()
    {

    }
}
