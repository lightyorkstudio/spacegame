﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleShot : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2.5f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
