using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbluedragon : MonoBehaviour
{
    public GameObject blueDragon;
    bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBlueDragon");
    }

    IEnumerator SpawnBlueDragon()
    {
        while (!gameover)
        {
            Instantiate(blueDragon, transform.position+new Vector3(Random.Range(-30,30),0,0), transform.rotation);
            yield return new WaitForSeconds(Random.Range(2, 3));
        }
        
    }
}
