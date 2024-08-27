using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float speed=5;
    public float jump=10;
    private bool grounded;
    private Animator animator;
    private bool m_FacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded=true;
    }

    void Update()
    {
        if(!GameManager.Instance.GetAlive()) return;
        move = Input.GetAxisRaw("Horizontal");
        if((move > 0 && !m_FacingRight) || (move < 0 && m_FacingRight)) Flip();
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
    void Flip()
	{
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}
    public void Death(){
        animator.SetFloat("Speed", 0);
        animator.enabled = false;
    }
    // void OnCollisionExit2D(Collision2D other){
    //     if(other.gameObject.CompareTag("Ground")){
    //         grounded=false;
    //     }
    // }
}
