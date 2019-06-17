using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{

    public Transform mainCam;

    float intensity = 0.2f;



    public IEnumerator Shake()
    {
        float t = 2;
        while (t > 0)
        {

            t -= Time.deltaTime;

            float randomX = Random.Range(-intensity * t, intensity * t);
            float randomY = Random.Range(-intensity * t, intensity * t);

            mainCam.transform.localPosition = new Vector3(randomX, randomY, 0);

            yield return null;
        }
    }

}
