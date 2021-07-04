using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    //Variables para gestionar el radio,el ataque y la velocidad
    public float velocidad;
    public float velocidadDeReversa;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public float rangoDeReversa;
    public float rangoDeDisparo;
    public bool mirandoALaDerecha;

    public int dañoEnemygo = 10;
    GameObject Player;
    Vida playerVida;

    

    public Transform player;
    public Rigidbody2D rb2d;
        // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerVida = Player.GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        MirandoAlPlayer();

        distanciaDelJugador = Vector2.Distance(player.position, rb2d.position);

        if(distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador > rangoDeDisparo){
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2d.position, objetivo, velocidad * Time.deltaTime);
            rb2d.MovePosition(nuevaPos); 
            
            }else if(distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador <= rangoDeDisparo){
                {
                    Vector2 objetivo = new Vector2(player.position.x, player.position.y);
                Vector2 nuevaPos = Vector2.MoveTowards(rb2d.position, objetivo, 0 * Time.deltaTime);
                rb2d.MovePosition(nuevaPos); 
                }
                
            }else if(distanciaDelJugador < rangoDeReversa){
                Vector2 objetivo = new Vector2(player.position.x, player.position.y);
                Vector2 nuevaPos = Vector2.MoveTowards(rb2d.position, objetivo, velocidadDeReversa * Time.deltaTime);
                rb2d.MovePosition(nuevaPos); 
                
            }
            
        }

public void MirandoAlPlayer(){
    Vector3 girado = transform.localScale;

    if(distanciaDelJugador < rangoDeVision){
        if(transform.position.x < player.position.x && !mirandoALaDerecha){
            Girar();
            mirandoALaDerecha = true;
        }
    }else if(transform.position.x > player.position.x && mirandoALaDerecha){
            Girar();
            mirandoALaDerecha = false;
        }
}

public void Girar(){
    transform.Rotate(0, 180, 0);
}

void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
                //float xOffset = 0.0f;
            
                playerVida.TakeDaño(dañoEnemygo);
            
        }
    }
    
    
private void OnDrawGizmos(){
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, rangoDeVision);
    Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
    Gizmos.DrawWireSphere(transform.position, rangoDeReversa);
}

}