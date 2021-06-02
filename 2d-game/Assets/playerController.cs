﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    public float maxForce = 1000f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private float groundRadius = 0.1f;
    private bool onTheGround = true;
    private bool wasOnTheGround = true;
    private SpriteRenderer spriteRend;
    private float inputX;
    [SerializeField]
    public Transform firingPoint;
    [SerializeField]
    public GameObject firePrefab;
    private bool isfacedLeft;
    public AudioSource myAudio;

   
    void Start(){
        animator = this.GetComponent<Animator>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        spriteRend = this.GetComponent<SpriteRenderer>();
        isfacedLeft = false;
    }

    void FixedUpdate(){

        onTheGround = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

        if (onTheGround != wasOnTheGround) { 
            animator.SetBool("isJumping",false); 
            wasOnTheGround = true;
        }

    }

    public void Move(InputAction.CallbackContext context){
        inputX = context.ReadValue<float>();
        myRigidbody.velocity =  new Vector2 (maxSpeed * inputX, myRigidbody.velocity.y);

        if (inputX>0){
            animator.SetInteger("direction",2);
            isfacedLeft = false;
            transform.localScale = new Vector3(4f,4f,1f);
        } else if (inputX<0){
            animator.SetInteger("direction",1);
            transform.localScale = new Vector3(-4f,4f,1f);
            isfacedLeft = true;
        } else {
            animator.SetInteger("direction",0);
        }
    }

    public void Jump(InputAction.CallbackContext context){
       if (onTheGround) {
            JumpSound();
            onTheGround = false;
            myRigidbody.AddForce (new Vector2 (0,maxForce));
            animator.SetBool("isJumping",true);
            wasOnTheGround = false;
        }
    }

    public void Fire(InputAction.CallbackContext context){
            float angle = isfacedLeft ? 180f : 0f;
            Instantiate(firePrefab,firingPoint.position, Quaternion.Euler(new Vector3(0f,0f,angle)));
    }

    public void JumpSound(){
        myAudio.Play();
    }
}
