using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Trompoline : MonoBehaviour
{
    public Animator anim;

    public float jumpForce = 2f;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col){
        if (col.transform.CompareTag("Player")){
            col.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            anim.Play("Trompoline_Jump");
        }
    } 
}
