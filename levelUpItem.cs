﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("levelUp");
        Destroy(gameObject);
    }
}
