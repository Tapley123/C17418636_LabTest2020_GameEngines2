﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarClass : StateMachineBehaviour
{
    public GameObject car;
    public float moveSpeed = 2f; //how fast the car drives
    public float rotationSpeed = 1f; //how fast the car turns
    public float accuracy = 1f; //how close the car needs to get to a green light
    public int currentMovePoint;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        car = animator.gameObject; //gettin the car game object
    }
}
