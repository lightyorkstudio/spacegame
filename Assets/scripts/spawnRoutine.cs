using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoutine : MonoBehaviour
{
     [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject spawnManager;
    [SerializeField]
    private GameObject[] powerup;
    //[SerializeField]
    //private GameObject powerup1;

    // Start is called before the first frame update
    private bool isalive = true;
    void Start()
    {

        StartCoroutine(spawn()); 
        StartCoroutine(powerups());
        //StartCoroutine(speedPowerup());
    }

    // Update is called once per frame
    void Update()
    {     
    
    }
    IEnumerator spawn(){
             while (isalive){

                 GameObject newEnemy = Instantiate(_enemy,new Vector3(Random.Range(5.15f,-5.15f),2.73f,0),Quaternion.identity);
                 newEnemy.transform.parent = spawnManager.transform;
                 yield return new WaitForSeconds (2f);    
             }
        }
    IEnumerator powerups(){
        while(isalive){
            int randomNo;
            randomNo = (Random.Range(0, 3));
            GameObject newpowerup = Instantiate(powerup[randomNo],new Vector3(Random.Range(5.15f,-5.15f),2.73f,0),Quaternion.identity);
           // newpowerup.transform.parent =spawnManager.transform;
            yield return new WaitForSeconds(Random.Range(5f,7f));
            }
    }
    // IEnumerator speedPowerup(){         
    //     while(isalive){
    //         GameObject speedpowerup = Instantiate(powerup1,new Vector3(Random.Range(5.15f,-5.15f),2.73f,0),Quaternion.identity);
    //         yield return new WaitForSeconds(Random.Range(8.0f,13f));
    //     }
        // }
    public void stateofplayerlife(){
        isalive = false;
        Destroy(this.gameObject);
    }
}

