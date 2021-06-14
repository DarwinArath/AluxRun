using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    Animator anim;
    public GameObject chestItem;
    public float chestDelay;

    bool itemPicked = false;

    public int itemAmount;
    int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.E) && !itemPicked){
                anim.Play("Cofre_Open");
                StartCoroutine(GetChestItems());
            }
        }
    }

    IEnumerator GetChestItems(){
        while (itemCount < itemAmount){
            yield return new WaitForSeconds(chestDelay);
            Instantiate(chestItem, transform.position, Quaternion.identity);
            itemPicked = true;

            itemCount++;
        }        
    }
}
