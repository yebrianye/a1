using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    
    public GameObject bullet;

    //public GameObject playerBulletLevel1, playerBulletLevel2, playerBulletLevel3, playerBigFire;
    public Transform nozzle;
    //public float fireRate;
    public int level = 1;

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
            level = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            level = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            level = 3;
        if (Input.GetKeyDown(KeyCode.Space))
            InvokeRepeating("shoot", 0, 0.25f);
        if (Input.GetKeyUp(KeyCode.Space))
            CancelInvoke("shoot");



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
        }
        if (level == 2)
        {
            GameObject mid = Instantiate(bullet, nozzle.position, nozzle.rotation);
            GameObject left = Instantiate(bullet, nozzle.position + new Vector3(-1, 0, 0), nozzle.rotation);
            GameObject right = Instantiate(bullet, nozzle.position + new Vector3(1, 0, 0), nozzle.rotation);
            left.transform.Rotate(new Vector3(0, -15, 0));
            right.transform.Rotate(new Vector3(0, 15, 0));
        }

        if (level == 3)
        {
            GameObject mid = Instantiate(bullet, nozzle.position, nozzle.rotation);
            GameObject left1 = Instantiate(bullet, nozzle.position + new Vector3(-1, 0, 0), nozzle.rotation);
            GameObject left2 = Instantiate(bullet, nozzle.position + new Vector3(-2, 0, 0), nozzle.rotation);
            GameObject right1 = Instantiate(bullet, nozzle.position + new Vector3(1, 0, 0), nozzle.rotation);
            GameObject right2 = Instantiate(bullet, nozzle.position + new Vector3(2, 0, 0), nozzle.rotation);

            left1.transform.Rotate(new Vector3(0, -15, 0));
            left2.transform.Rotate(new Vector3(0, -30, 0));
            right1.transform.Rotate(new Vector3(0, 15, 0));
            right2.transform.Rotate(new Vector3(0, 30, 0));
        }

    }
}
