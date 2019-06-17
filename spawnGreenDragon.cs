using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGreenDragon : MonoBehaviour
{
    public GameObject greenDragon;
    bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawngreenDragon");
    }

    IEnumerator SpawngreenDragon()
    {
        while (!gameover)
        {
            Instantiate(greenDragon, transform.position + new Vector3(Random.Range(-30, 30), 0, 0), transform.rotation);
            yield return new WaitForSeconds(Random.Range(8, 14));
        }

    }
}
