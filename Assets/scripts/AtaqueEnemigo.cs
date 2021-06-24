using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{   
    public int dañoEnemygo = 10;
    GameObject Player;
    Vida playerVida; //COMPONENTE SCRIPT
    
    // Start is called before the first frame update
    public void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerVida = Player.GetComponent<Vida>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col){
    if(col.CompareTag("Player")){
        playerVida.TakeDaño(dañoEnemygo);
       }
    } 

}
