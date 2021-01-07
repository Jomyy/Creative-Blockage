using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour
{
    private Collider2D coll;
    private SpriteRenderer rend;
    private bool one = true;
    void Start()
    {
        
        coll = GetComponent<Collider2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player") && one){
            Invoke("DestroyPlatform",0.4f);
            one = false;
        }
    }
    void DestroyPlatform(){
        coll.enabled = false;
        rend.enabled = false;
        Invoke("EnablePlatform",10);
    }
    void EnablePlatform(){
        coll.enabled = true;
        rend.enabled = true;
        one = true;
    }
    
    
}
