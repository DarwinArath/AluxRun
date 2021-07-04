using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbismoDanio : MonoBehaviour
{
    public int dañoEnemygo = 10;
    GameObject Player;
    Vida playerVida;
    // Start is called before the first frame update
    void Start()
    {
         Player = GameObject.FindGameObjectWithTag("Player");
        playerVida = Player.GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
                //float xOffset = 0.0f;
            
                playerVida.TakeDaño(dañoEnemygo);
            
        }
    }
}
