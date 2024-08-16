using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool isJumping = false, isCrouching;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")){
            isJumping = true;
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
}
