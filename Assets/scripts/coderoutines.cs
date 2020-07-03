using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class codeRoutines : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(spawn()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn(){
    while (true)
    {
        Instantiate(_enemy,new Vector3(Random.Range(5.15f,-5.15f),2.73f,0),Quaternion.identity);
         yield return new WaitForSeconds (2f);
     }
    
    }
    
}
