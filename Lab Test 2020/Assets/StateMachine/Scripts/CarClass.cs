using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarClass : StateMachineBehaviour
{
    public GameObject car;
    public float maxMoveSpeed = 4f; //how fast the car drives
    public float slowingSpeed; //slower speed for arrive steering behavior
    public float slowingDistance = 4f; //distance car needs to be from the light before it starts to slow down

    public float rotationSpeed = 2f; //how fast the car turns 
    public float accuracy = 4f; //how close the car needs to get to a green light
    public int currentMovePoint;
    
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        car = animator.gameObject; //gettin the car game object
    }

}
