﻿using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    public GameObject Attack; 
    Animator animator;
    Animator attackAnim;


    //animation states - the values in the animator conditions
    const int STATE_FRONT_IDLE = 0;
    const int STATE_BACK_IDLE = 2;
    const int STATE_LEFT_IDLE = 4;
    const int STATE_RIGHT_IDLE = 6;
    const int STATE_WALKDOWN = 1;
    const int STATE_WALKUP = 3;
    const int STATE_WALKLEFT = 5;
    const int STATE_WALKRIGHT = 7;

    int _currentAnimationState = STATE_FRONT_IDLE;
    string direction = "front";

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
        attackAnim = Attack.GetComponent<Animator>();
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update()
    {
        //Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject AttackClone = Attack;
            AttackClone.gameObject.GetComponent<AttackScript>().direction = direction;
            AttackClone = (GameObject)Instantiate(Attack, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Left
        {
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            changeState(STATE_WALKLEFT);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))   //Walk Left
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKLEFT);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))  //Left Idle
        {
            changeState(STATE_LEFT_IDLE);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Right
        {
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            changeState(STATE_WALKRIGHT);
        }
        else if (Input.GetKey(KeyCode.RightArrow))  //Walk Right
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKRIGHT);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //Right Idle
        {
            changeState(STATE_RIGHT_IDLE);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
        {
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
        }
        else if (Input.GetKey(KeyCode.UpArrow))   //Walk Up
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))  //Up Idle
        {
            changeState(STATE_BACK_IDLE);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
        {
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
        }
        else if (Input.GetKey(KeyCode.DownArrow))  //Walk Down
        {
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))  //Down Idle
        {
            changeState(STATE_FRONT_IDLE);
        }
    }

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {

            case STATE_WALKUP:
                animator.SetInteger("State", STATE_WALKUP);
                direction = "up";
                break;

            case STATE_WALKDOWN:
                animator.SetInteger("State", STATE_WALKDOWN);
                direction = "down";
                break;

            case STATE_WALKLEFT:
                animator.SetInteger("State", STATE_WALKLEFT);
                direction = "left";
                break;

            case STATE_WALKRIGHT:
                animator.SetInteger("State", STATE_WALKRIGHT);
                direction = "right";
                break;

            case STATE_FRONT_IDLE:
                animator.SetInteger("State", STATE_FRONT_IDLE);
                direction = "down";
                break;
            case STATE_BACK_IDLE:
                animator.SetInteger("State", STATE_BACK_IDLE);
                direction = "up";
                break;
            case STATE_LEFT_IDLE:
                animator.SetInteger("State", STATE_LEFT_IDLE);
                direction = "left";
                break;
            case STATE_RIGHT_IDLE:
                animator.SetInteger("State", STATE_RIGHT_IDLE);
                direction = "right";
                break;

        }

        _currentAnimationState = state;
    }

}
