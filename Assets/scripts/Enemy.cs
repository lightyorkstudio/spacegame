using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    [SerializeField]
    private float _bottomscreen = -3f;
    [SerializeField]
    private float _appeartop =2.73f;
    // Start is called before the first frame update
    void Start()
    {
        float x1;
        //this shows spawning position
        x1=Random.Range(5.15f,-5.15f);
        transform.position=new Vector3(x1,_appeartop,0);
    }

    // Update is called once per frame
    void Update()
    {
        //here the code talks about enemy behaviour
        
        transform.Translate(Vector3.down*Time.deltaTime*_speed);
        if (transform.position.y<_bottomscreen){
            transform.position= new Vector3(Random.Range(5.15f,-5.15f),_appeartop,0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        //when players life hit zero destroy the player. 
        if (other.tag == "Player"){
            Destroy(this.gameObject);
            Player_mat player=other.transform.GetComponent<Player_mat>();
            if(player!=null){
                player.Damage();
            }              
        } 
        //destroy enemy after getting hit     
        if (other.tag == "laser"){
            Destroy(this.gameObject);
            Destroy(other.gameObject);         
        }
    }    
}
