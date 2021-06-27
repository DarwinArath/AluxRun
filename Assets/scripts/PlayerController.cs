using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;
    public bool atacar = false;
    
	private Rigidbody2D rb2d;
	private Animator anim;
	private SpriteRenderer spr;
	private bool jump;
	private bool movement = true;

    // Start is called before the first frame update
    void Start()
    {	

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
        	jump = true;
        }
    }

    void FixedUpdate(){

    	//fidedVelocity para disminuir la friccion
    	Vector3 fixedVelocity = rb2d.velocity;
    	fixedVelocity.x *= 0.75f;

    	if(grounded){
    		rb2d.velocity = fixedVelocity;
    	}
    	
    	//metodo pararealizar desplazamieto
    	float h = Input.GetAxis("Horizontal");
		if(!movement) h =0;

    	rb2d.AddForce(Vector2.right * speed * h);

    	float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed,  maxSpeed);
    	rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

    	//debug.Log(rb2d.velocity.x);

    	//comparacion para cambiar direccion de animacion
    	if(h > 0.1f){
    		transform.localScale = new Vector3(1f, 1f, 1f);
    	}

    	if(h < -0.1f){
    		transform.localScale = new Vector3(-1f, 1f, 1f);
    	}

    	//salto
    	
		if(jump){
		rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
		rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
		jump =  false;
		}

        //atacar
    	
        if(Input.GetKeyDown("space")){
            anim.SetTrigger("Atacar");
        }
        
    }

    //METODO PARA VERICAR QUE EL PERSONAJE ESTE CAENDO, SI ES ASI QUE REGRESA A LA PLATAFORMA

    void OnBecameInvisible(){
    	transform.position = new Vector3(0,0,0);
    }

	//Codigo para provocar salto al colisionar con otro objeto (una serpiente)

	public void EnemyJump(){
		jump = true;
	}	

	public void EnemyKnockBack(float enemyPosX){
	
	//healthbar.SendMessage("TakeDamage", danio);

	//jump = true;

	float side = Mathf.Sign(enemyPosX = transform.position.x);
	rb2d.AddForce(Vector2.left*side*jumpPower, ForceMode2D.Impulse);

		movement = false;
		Invoke("EnableMovement", 0.7f);

		spr.color = Color.red;
	}

	void EnableMovement(){
		movement = true;
		
		spr.color = Color.white;

	}

	/*private void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy"){
		vidaslider.value -= daño;
		}
	}*/
	
	/*private void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Enemy")){
			curHealth -= col.GetComponent<EnemySnake>().danio;
			healthBar.fillAmount = curHealth / maxHealth;

			if(curHealth <= 0){
				GameOver.show ();
			}
		}
	}*/
}

