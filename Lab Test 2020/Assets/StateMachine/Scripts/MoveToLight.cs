using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLight : CarClass
{
    private Circle circle;
    private float moveSpeed;

    private void Awake()
    {
        circle = GameObject.Find("circle").GetComponent<Circle>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex); //run the onstart for the CarClass script
        moveSpeed = maxMoveSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PickLight.target == PickLight.center)
            return;

        if (circle.greenLights.Count == 0) //if there are no green lights
            animator.SetBool("move", false);



        float dist = Vector3.Distance(PickLight.target.position, car.transform.position);
        //Debug.Log("Distance = " + dist);
        slowingSpeed = (dist / slowingDistance) * maxMoveSpeed;
        Debug.Log("move speed = " + moveSpeed);

        if(dist <= slowingDistance)
            moveSpeed = (dist / slowingDistance) * maxMoveSpeed;

        car.transform.Translate(0, 0, Time.deltaTime * moveSpeed); //move the car forward by the movespeed



        if (dist <= accuracy) //if the car has gotten within the close distance of the light
        {
            animator.SetBool("move", false);
        }
            
            

        Vector3 direction = PickLight.target.position - car.transform.position; //get the direction
        car.transform.rotation = Quaternion.Slerp(car.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime); //slerp the rotation of the car to face the green light it is going towards

        

        Debug.DrawLine(car.transform.position, PickLight.target.position, Color.blue); //draw a line from the car to the green light it is targeting

        if(PickLight.target.GetComponent<ColourChanger>().green == false) //if the colour changes to green while the car is driving towards it 
        {
            animator.SetBool("move", false);
        }
    }
}
