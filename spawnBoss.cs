using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnBoss : MonoBehaviour
{
    public GameObject boss;
    bool gameover;
    float t = 60;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawnboss");
    }

    IEnumerator Spawnboss()
    {

        while (t>0)
        {
            t -= Time.deltaTime;
            
            yield return null;
        }
        Instantiate(boss, transform.position, transform.rotation);
    }
}
