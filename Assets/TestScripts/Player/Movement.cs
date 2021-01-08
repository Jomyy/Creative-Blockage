using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform feetPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpStrength;
    [SerializeField]
    private float hoverStrength;
    [SerializeField]
    private float groundCheck;
    public LayerMask GroundLayer;
    private bool isGrounded;
    private float Horizontal;
    private Rigidbody2D rb;
    private float GroundedTimer;
    public float GroundedTimerRef;
    private float PressedTimer;
    public float PressedTimerRef;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
       
        Horizontal = Input.GetAxisRaw("Horizontal") * speed;
        isGrounded = Physics2D.OverlapCircle(feetPos.position,groundCheck,GroundLayer);
        Jump();
    }
    void FixedUpdate(){
        if(Horizontal != 0 && isGrounded){
            rb.velocity = new Vector2(Horizontal,rb.velocity.y);
        }else if(Horizontal != 0 && !isGrounded){
            rb.velocity = new Vector2(Horizontal * 1.2f,rb.velocity.y);
        }
        if(Horizontal == 0 && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x * 0.5f,rb.velocity.y);
        }else if(Horizontal == 0 && !isGrounded){
            rb.velocity = new Vector2(rb.velocity.x * 0.9f,rb.velocity.y);
        }
        
    }
    void Jump(){
        GroundedTimer -= Time.deltaTime;
        PressedTimer -= Time.deltaTime;
        if(isGrounded){
            GroundedTimer = GroundedTimerRef;
        }
        if(Input.GetButtonDown("Jump")){
            PressedTimer = PressedTimerRef;
        }
        if(GroundedTimer > 0 && PressedTimer > 0 && rb.velocity.y <= 0){
            rb.velocity = new Vector2(rb.velocity.x,jumpStrength);
            GroundedTimer = 0;
            PressedTimer = 0;
        }
        if(rb.velocity.y > 0 && rb.velocity.y < 1.5f && !Input.GetButton("Jump") && !isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.9f);
        }
        if(rb.velocity.y > 1.5f && rb.velocity.y < 3 && !Input.GetButton("Jump") && !isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.7f);
        }
        if(rb.velocity.y > 3 && !Input.GetButton("Jump") && !isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.5f);
        }

    }
}