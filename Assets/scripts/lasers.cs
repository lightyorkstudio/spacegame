using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lasers : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
 

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);transform.position.x
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,_speed,0)*Time.deltaTime);
        if (transform.position.y >= 2.5f)
        {
            Destroy(this.gameObject);
            if (transform.parent != null)
            {

                Destroy(transform.parent.gameObject);
            }
        }
        
    

    }
   
}
