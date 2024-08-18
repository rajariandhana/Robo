using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool isJumping = false, isCrouching = false;

    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
        if(Input.GetButtonDown("Crouch")){
            isCrouching = true;
        }
        else if(Input.GetButtonUp("Crouch")){
            isCrouching = false;
        }
    }
    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime,isCrouching,isJumping);
        isJumping = false;
    }
    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching2){
        animator.SetBool("IsCrouching",isCrouching2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Debug.Log("Player got hit by the rocket!");
        }
    }
}
