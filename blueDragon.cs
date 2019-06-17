using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueDragon : MonoBehaviour
{


    public GameObject bulletpack1;
    public Transform nozzle;

    public float fireRate=3;




    // Use this for initialization
    void Start()
    {
        InvokeRepeating("shoot", 0, fireRate);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z < -20)
            Destroy(gameObject);
    }

    void shoot()
    {
        Instantiate(bulletpack1, nozzle.position, nozzle.rotation);
    }

    public int bluehealth = 100;
    public GameObject theParticle;
    public GameObject hitParticle;

    public void hit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        if(Time.deltaTime>30)
            bluehealth -= 8;
        if (Time.deltaTime > 60)
            bluehealth -= 5;
        else
            bluehealth -= 10;
        print(bluehealth);
        if (bluehealth <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addscore");
            Instantiate(theParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

    void hughit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        bluehealth -= 100;
        print(bluehealth);
        if (bluehealth <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addscore");
            Instantiate(theParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            



        }
    }
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("hit");
    }

}

