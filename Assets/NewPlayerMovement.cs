using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float move;
    public float speed=5;
    public float jump=10;
    private bool grounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded=true;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if(Input.GetButtonDown("Jump") && grounded){
            rb.AddForce(new Vector2(rb.velocity.x, jump*10));
            grounded=false;
            animator.SetBool("IsJumping", true);
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            // Vector3 normal = other.GetContact(0).normal;
            // if(normal==Vector3.up){
                grounded=true;
                animator.SetBool("IsJumping", false);
            // }
        }
    }
    // void OnCollisionExit2D(Collision2D other){
    //     if(other.gameObject.CompareTag("Ground")){
    //         grounded=false;
    //     }
    // }
}
