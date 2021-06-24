using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
        EnemySnake enemy; 
        public GameObject deathEffect;

    private void Start()
    {
	    enemy = GetComponent<EnemySnake>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.CompareTag("Weapon"))
        {
	        enemy.healthPoints -=2f;
	
	        if (enemy.healthPoints <= 0)
	        {
            Instantiate(deathEffect,transform.position, Quaternion.identity);
		    Destroy(gameObject);
	        }
        }
    }
}
