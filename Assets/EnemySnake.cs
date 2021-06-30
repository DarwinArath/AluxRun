using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;
    public string enemyName;
    public float healthPoints; 

    //public float danio;

     public int dañoEnemygo = 10;
    GameObject Player;
    Vida playerVida;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        Player = GameObject.FindGameObjectWithTag("Player");
        playerVida = Player.GetComponent<Vida>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        rb2d.AddForce(Vector2.right * speed);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed,  maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        //comparacion para cambiar direccion de animacion
        if(speed < 0){
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(speed > 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
                //float xOffset = 0.0f;
            
                playerVida.TakeDaño(dañoEnemygo);
            
        }
    }
}
    /*
        private void OnTriggerEnter(Collider col){
    if(col.CompareTag("Player")){
        playerVida.TakeDaño(dañoEnemygo);
       }
    }

     void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            
            //float yOffset = 0.04f;
            if(transform.position.x < col.transform.position.x){
                //col.SendMessage("EnemyJump");
                //Destroy(gameObject);
                playerVida.TakeDaño(dañoEnemygo);
            }else{
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }
    }
    */


