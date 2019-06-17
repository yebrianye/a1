using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //audio
    public AudioClip m_shootClip;
    public AudioClip m_bigfireClip;
    public AudioClip m_getHitClip;
    public AudioClip m_deadClip;
    public AudioClip m_levelUpClip;

    public AudioSource m_audio;

    Rigidbody rigi;
    float verti, hori, speed = 30;
    Vector3 movement;
    public Transform banking;

    public GameObject bullet;
    public GameObject bigFireBall;

    //public GameObject playerBulletLevel1, playerBulletLevel2, playerBulletLevel3, playerBigFire;
    public Transform nozzle;
    //public float fireRate;
    int level = 1;
    int bigFireCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();//assign the rigidbody automaticly
        
        m_audio = this.m_audio;
        
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");
        print(hori);

        banking.localEulerAngles = new Vector3(0, 0, -hori * 45);

        if ((verti < 0 && transform.position.z > -2) || (verti > 0 && transform.position.z < 65))
            movement.z = verti * speed;
        else
            movement.z = 0;

        if ((hori < 0 && transform.position.x >- 21) || (hori > 0 && transform.position.x < 21))
            movement.x = hori * speed;
        else
            movement.x = 0;

        rigi.velocity = movement;

        if (bigFireCount>0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bigFire();
                m_audio.PlayOneShot(m_bigfireClip);
            }
                


        }

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
            level = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            level = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            level = 3;*/
        if (level == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("shoot", 0, 0.2f);
                
            }

            
            if (Input.GetKeyUp(KeyCode.Space))
                CancelInvoke("shoot");
        }
        if (level == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                InvokeRepeating("shoot", 0, 0.3f);
            if (Input.GetKeyUp(KeyCode.Space))
                CancelInvoke("shoot");
        }
        if (level == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                InvokeRepeating("shoot", 0, 0.4f);
            if (Input.GetKeyUp(KeyCode.Space))
                CancelInvoke("shoot");
        }


    }

    public int health = 300;
    public GameObject theParticle;
    public GameObject hitParticle;
    public GameObject levelupParticle;

    public void hit()
    {
        GameObject.FindWithTag("actualCamera").SendMessage("Shake");
        Instantiate(hitParticle, transform.position, transform.rotation);
        health -= 10;
        print(health);
        m_audio.PlayOneShot(m_getHitClip);
        if (health <= 0)
        {
            dead();
        }
    }
    
    public void levelUp()
    {
        if (level < 3)
            level++;
        else
        {
            level = level;
            health = health + 10;
        }
        Instantiate(levelupParticle, transform.position, transform.rotation);
        m_audio.PlayOneShot(m_levelUpClip);
        bigFireCount++;
        GameObject.FindWithTag("gamemanager").SendMessage("addscore");
    }

    void shoot()
    {
        /* if (level == 1)
             Instantiate(playerBulletLevel1, nozzle.position, nozzle.rotation);
         if (level == 2)
             Instantiate(playerBulletLevel2, nozzle.position, nozzle.rotation);
         if (level == 3)
             Instantiate(playerBulletLevel3, nozzle.position, nozzle.rotation);*/
        if (level == 1)
        {
            GameObject mid = Instantiate(bullet, nozzle.position, nozzle.rotation);
            m_audio.PlayOneShot(m_shootClip);

        }
        if (level == 2)
        {
            GameObject mid = Instantiate(bullet, nozzle.position, nozzle.rotation);
            GameObject left = Instantiate(bullet, nozzle.position + new Vector3(-1, 0, 0), nozzle.rotation);
            GameObject right = Instantiate(bullet, nozzle.position + new Vector3(1, 0, 0), nozzle.rotation);
            left.transform.Rotate(new Vector3(0, -10, 0));
            right.transform.Rotate(new Vector3(0, 10, 0));

            m_audio.PlayOneShot(m_shootClip);
        }

        if (level == 3)
        {
            GameObject mid = Instantiate(bullet, nozzle.position, nozzle.rotation);
            GameObject left1 = Instantiate(bullet, nozzle.position + new Vector3(-1, 0, 0), nozzle.rotation);
            GameObject left2 = Instantiate(bullet, nozzle.position + new Vector3(-2, 0, 0), nozzle.rotation);
            GameObject right1 = Instantiate(bullet, nozzle.position + new Vector3(1, 0, 0), nozzle.rotation);
            GameObject right2 = Instantiate(bullet, nozzle.position + new Vector3(2, 0, 0), nozzle.rotation);

            left1.transform.Rotate(new Vector3(0, -10, 0));
            left2.transform.Rotate(new Vector3(0, -20, 0));
            right1.transform.Rotate(new Vector3(0, 10, 0));
            right2.transform.Rotate(new Vector3(0, 20, 0));

            m_audio.PlayOneShot(m_shootClip);
        }

    }
    void bigFire()
    {
            GameObject mid = Instantiate(bigFireBall, nozzle.position, nozzle.rotation);
        bigFireCount--;
    }

    void dead()
    {
        m_audio.PlayOneShot(m_deadClip);
        Instantiate(theParticle, transform.position, transform.rotation);

        Destroy(gameObject);
        GameObject.FindWithTag("gamemanager").SendMessage("EndGame");
        
    }
    
}
