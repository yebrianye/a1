using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDragon : MonoBehaviour
{
    public GameObject bulletpack1;
    public Transform nozzle;
    public GameObject levelUpItem;

    public float fireRate = 3;




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

    public int health = 300;
    public GameObject theParticle;
    public GameObject hitParticle;

    IEnumerator hit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        health -= 10;
        print(health);
        if (health <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addscore");
            Instantiate(theParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            while (true)
            {
                
                Instantiate(levelUpItem, transform.position, transform.rotation);
                yield return null;
            }

            

        }
    }

    IEnumerator hughit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        health -= 100;
        print(health);
        if (health <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addscore");
            Instantiate(theParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            while (true)
            {

                Instantiate(levelUpItem, transform.position, transform.rotation);
                yield return null;
            }


        }
    }
    

}
