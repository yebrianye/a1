using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject bulletpack2;
    public Transform nozzle;

    public float fireRate = 3;

    public AudioClip m_showUpClip;

    public AudioSource m_audio;



    // Use this for initialization
    void Start()
    {
        InvokeRepeating("shoot", 0, fireRate);
        m_audio = this.m_audio;
        m_audio.PlayOneShot(m_showUpClip);

    }

    

    void shoot()
    {
        Instantiate(bulletpack2, nozzle.position, nozzle.rotation);
    }

    public int health = 6000;
    public GameObject theParticle;
    public GameObject hitParticle;

    void hit()
    {
        Instantiate(hitParticle, transform.position, transform.rotation);
        health -= 10;
        print(health);
        if (health <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addbossscore");
            dead();
            
            
        }
    }

    void hughit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        health -= 100;
        print(health);
        if (health <= 0)
        {
            GameObject.FindWithTag("gamemanager").SendMessage("addbossscore");
            dead();
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }

    void dead()
    {
        Instantiate(theParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        GameObject.FindWithTag("gamemanager").SendMessage("Winning");
    }
}
