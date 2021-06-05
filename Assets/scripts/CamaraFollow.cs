using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Metodod para seguimiento de camara
public class CamaraFollow : MonoBehaviour
{
	public GameObject follow;
	public Vector2 minCamPos, maxCamPos;
	public float smoothTime;
    // Start is called before the first frame update

    private Vector2 velocity;

    void Start()
    {
        
    }

    void FixedUpdate(){
    	/*	
    	float posX = follow.transform.position.x;
    	float posY = follow.transform.position.y;
		*/
    	
    	float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
    	float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);
    	

    	transform.position = new Vector3(
    		Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
    		Mathf.Clamp(posY, minCamPos.x, maxCamPos.x),
    		transform.position.z);
    }
}
