using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    private GameObject Player;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
        rend.forceRenderingOff = true;
    }
    void Update(){
        if(Vector2.Distance(Player.transform.position,transform.position) < 3){
            rend.forceRenderingOff = false;
        }else{
            rend.forceRenderingOff = true;
        }
        
            
        
    }

   
}
