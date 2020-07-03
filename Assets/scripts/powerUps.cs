using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float ID =0;
    private bool playerdeath;
    // Start is called before the first frame update
    void Start()
    {
       // transform.position =new Vector3(Random.Range(5,-5),2.3f,0);
    }

    // Update is called once per frame
    void Update()
    {
       // playerdeath=GameObject.Find("player").GetComponent<Player_mat>().death;
        movement();
    }
    private void OnTriggerEnter2D(Collider2D other) {      
    
        if (other.tag == "Player"){
            Death();
           // gameObject trippleShot =
          //GameObject trippleShot = GameObject.Find("Player");        
          //Player_mat player=trippleShot.GetComponent<Player_mat>(); 
          Player_mat player =other.transform.GetComponent<Player_mat>();
          if (player != null){
            switch(ID){
                case 0:

                    player.addfirerate();
                    break;
                case 1:
                    player.Movefast();
                    break;
                case 2:
                    player.sheildon();
                    // Debug.Log("collected sheild");
                    break;
                default:
                    Debug.Log("default case");
                    break;
            }
          }            
        }            
    } 
    private void movement(){
        transform.Translate(new Vector3(0,1,0)*-_speed*Time.deltaTime);
        if (transform.position.y<-2.5){
            Death();
        }
    }
    private void Death(){
        Destroy(this.gameObject);
    }    
}
