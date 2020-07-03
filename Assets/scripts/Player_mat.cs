using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player_mat : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject tripleshoot;
    [SerializeField]
    private float _firerate=2;
    private float _canfire;
    [SerializeField]
    private float _lives = 3f;
    private spawnRoutine _stateofplayerlife;
    [SerializeField]
    private bool tripleisactive = true;
    public bool death = false;
    [SerializeField]
    private GameObject powerup ;
    [SerializeField]
    private bool sheild,fastpowerup = false;
    private float _speedincrease =2f;
    // Start is called before the first frame update
    void Start() 
    {
        StartCoroutine(moveFast());
       transform.position = new Vector3(0, 0, 0);
        //transform.Translate(Vector3)
        _stateofplayerlife = GameObject.Find("spawnRoutine").GetComponent<spawnRoutine>();  
        if (_stateofplayerlife== null){
            Debug.Log("state of player cannot be reached");

        }                
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space)){
            shoot();}  
        if (_firerate<1){
            tripleisactive = false;
        }    
        movment();
    }
    void movment()
    {
        if (transform.position.x>5.0f){
            transform.position= (new Vector3(-5.0f,transform.position.y,0));
        }
        else if (transform.position.x<-5.0f)
        {
            transform.position=(new Vector3(5.0f,transform.position.y,0));
        }
        if(transform.position.y > 2.5f){
            transform.position=(new Vector3(transform.position.x,2.5f,0));

        }
        else if(transform.position.y <-2.5f){
            transform.position=(new Vector3(transform.position.x,-2.5f,0));
        }
        float horizantalInput =Input.GetAxis("Horizontal"); 
        float verticalInput =Input.GetAxis("Vertical");   
        if (fastpowerup == true){ 
            transform.Translate(Vector3.right * _speed *_speedincrease *horizantalInput* Time.deltaTime );
            transform.Translate(Vector3.up * _speed *_speedincrease*verticalInput*Time.deltaTime);
            }
        else{    
            transform.Translate(Vector3.right * _speed *horizantalInput* Time.deltaTime );
            transform.Translate(Vector3.up * _speed *verticalInput* Time.deltaTime );
        // timer +=Time.deltaTime;    
        }     
    } 
    public void Damage(){
        if (sheild == true){
            sheild = false;
            return;
        }
        _lives --;
        if(_lives<1){
            Destroy(this.gameObject);
            
            _stateofplayerlife.stateofplayerlife();
            death = true;
        }
    }  
    private void shoot(){
        if (tripleisactive == true){
            Instantiate(tripleshoot,transform.position ,Quaternion.identity);
            _firerate = _firerate - 1;
        }
        else {            
            Instantiate(_laserPrefab,transform.position+new Vector3(0,1.166f,0),Quaternion.identity);        
        }
    }
    public void addfirerate(){
        _firerate =7;
        tripleisactive = true;
       // Debug.Log("firerate works");
    }   
    IEnumerator moveFast(){
        while(fastpowerup){      
            yield return new WaitForSeconds(5f);
            fastpowerup = false;
            //Debug.Log("stop");
        }   
    }  
    public void Movefast(){
        fastpowerup =true;
      // Debug.Log("start up");
    }
    public void sheildon(){
        sheild = true;
    }
}