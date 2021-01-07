using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityPlatform : MonoBehaviour
{
    private Collider2D coll;
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    void Start(){
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    private float Timer;
    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            if(rb.velocity.x == 0){
                Timer -= Time.deltaTime;
                if(Timer <0){
                    DestroyPlatform();
                }
            }else{
                Timer = 1;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            Timer = 1f;
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
        
    }
}
