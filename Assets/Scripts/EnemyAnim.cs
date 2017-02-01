﻿using UnityEngine;
using System.Collections;
using UnityEditor.Animations;
//bbusing UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAnim : MonoBehaviour {
	//Debug
	public string dir;



	NavMeshAgent Agent;

	//private Vector3 velocity, smoothDeltaPosition = Vector2.zero;
	private Vector3 A,B,D;
	private Vector3 AD, BD;


	//How many these are used will depend on the enemy
	public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT =3, DIR_RIGHT =2;
	public bool ATTACK = false, DED = false;

    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update(){
		Agent = gameObject.GetComponent<NavMeshAgent>();
		D = GameObject.Find("Camera").GetComponent<Camera>().transform.position;
		B = Agent.steeringTarget;
		A = transform.position;
		AD = D - A;
		BD = D - B;
		Vector3 viewport = Vector3.Cross (AD, BD);
		if (viewport.y >0) {
			//heading right
			dir = "right";
			anim.SetInteger("Dir",DIR_RIGHT);
		} else {

			//heading left
			dir = "left";
			anim.SetInteger("Dir",DIR_LEFT);
		}
	}

    void changeState(int state)
    {
        if (_currentAnimationState == state){
            return;
        }
    }

    private string getDirection()
    {
        return direction;
    }

    void changeState(int state)
    {
        if (_currentAnimationState == state){
            return;
        }

        switch (state)
        {
            case STATE_FRONT_IDLE:
                anim.SetInteger("State", STATE_FRONT_IDLE);
                break;
            case STATE_FRONT_MOVE:
                anim.SetInteger("State", STATE_FRONT_MOVE);
                break;
            case STATE_FRONT_ATTACK:
                anim.SetInteger("State", STATE_FRONT_ATTACK);
                break;
            case STATE_FRONT_DEATH:
                anim.SetInteger("State", STATE_FRONT_DEATH);
                break;
            case STATE_BACK_IDLE:
                anim.SetInteger("State", STATE_BACK_IDLE);
                break;
            case STATE_BACK_MOVE:
                anim.SetInteger("State", STATE_BACK_MOVE);
                break;
            case STATE_BACK_ATTACK:
                anim.SetInteger("State", STATE_BACK_ATTACK);
                break;
            case STATE_BACK_DEATH:
                anim.SetInteger("State", STATE_BACK_DEATH);
                break;
            case STATE_LEFT_IDLE:
                anim.SetInteger("State", STATE_LEFT_IDLE);
                break;
            case STATE_LEFT_MOVE:
                anim.SetInteger("State", STATE_LEFT_MOVE);
                break;
            case STATE_LEFT_ATTACK:
                anim.SetInteger("State", STATE_LEFT_ATTACK);
                break;
            case STATE_LEFT_DEATH:
                anim.SetInteger("State", STATE_LEFT_DEATH);
                break;
            case STATE_RIGHT_IDLE:
                anim.SetInteger("State", STATE_RIGHT_IDLE);
                break;
            case STATE_RIGHT_MOVE:
                anim.SetInteger("State", STATE_RIGHT_MOVE);
                break;
            case STATE_RIGHT_ATTACK:
                anim.SetInteger("State", STATE_RIGHT_ATTACK);
                break;
            case STATE_RIGHT_DEATH:
                anim.SetInteger("State", STATE_RIGHT_DEATH);
                break;
        }
    }

    private string getDirection()
    {
        return direction;
    } */
}
