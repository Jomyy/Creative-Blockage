using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rb;
    public float speed;
    public float jumpStrength;
    private float Horizontal;
    private float Vel;

    private int frameCount;
    public float jumpTimer;
    public float isGroundedTimer;
    private float jumpTimerCount;
    private float isGroundedCount;
    
    public Transform feetPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    #endregion
    void Update()
    {
        Run();
        Jump();
    }
    void FixedUpdate()
    {
        FixedRun();
    }
    void Run(){
        //Getting Player Input
        Horizontal = Input.GetAxis("Horizontal") * speed;
    }
    void FixedRun(){
        // making accel and deccel exatly like in celeste lol thx Mark brown for making the graphs lololololo
        frameCount ++;
        if(frameCount == 1 &&  Input.GetAxisRaw("Horizontal")== 0 && rb.velocity.x != 0){
            rb.velocity = new Vector2(rb.velocity.x/3,rb.velocity.y);
        }else
        if(frameCount == 2 && Input.GetAxisRaw("Horizontal") == 0 && rb.velocity.x != 0){
            rb.velocity = new Vector2(rb.velocity.x- (rb.velocity.x/3)*2,rb.velocity.y);
        }else
        if(frameCount == 3 && Input.GetAxisRaw("Horizontal") == 0 && rb.velocity.x != 0){
            rb.velocity = new Vector2(0,rb.velocity.y);
            frameCount = 0;
        }else{
            frameCount =0;
        }
        
        
        // actualy setting velocity 
        if(Input.GetAxisRaw("Horizontal") != 0){
            
            rb.velocity = new Vector2(Horizontal * Time.fixedDeltaTime,rb.velocity.y);
        }
    }
    void Jump(){
        jumpTimerCount -= Time.deltaTime;
        isGroundedCount -= Time.deltaTime;
        //CHecking if player Pressed or presses the JumpButton for JUICE
        if(Input.GetButtonDown("Jump")){
            jumpTimerCount = jumpTimer;
        }
        //Checking if player is or was grounded was for the JUICE
        if(Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround)){

            isGroundedCount = isGroundedTimer;
            
            
        }
        //actual Jump Code
        if(jumpTimerCount > 0 && isGroundedCount >0 ){
            
            rb.velocity = new Vector2(rb.velocity.x,jumpStrength);
            isGroundedCount = 0;
            jumpTimerCount = 0;
            
        }
        //for making variable jump height
        if(!Input.GetButton("Jump")){
            if(rb.velocity.y > 0.4f){
                //rb.velocity -= new Vector2(0,rb.velocity.y  * Time.deltaTime * 4);
                rb.velocity *= 0.8f;
            }
            
        }
        
    }
}
