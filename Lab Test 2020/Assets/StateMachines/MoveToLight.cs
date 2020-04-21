using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLight : CarClass
{
    private Circle circle;

    private void Awake()
    {
        circle = GameObject.Find("Trafic Light Manager").GetComponent<Circle>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex); //run the onstart for the CarClass script 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (circle.greenLights.Count == 0) //******************************************************************************PUT STATE IF THERE ARE NO GREEN LIGHTS HERE!!!!!
            return; //if there are no green lights dont run

        if (Vector3.Distance(circle.greenLights[currentMovePoint].transform.position, car.transform.position) < accuracy) //if the car has gotten within the close distance of the light
            animator.SetTrigger("LookForLight"); //change to the look for light state

        var direction = circle.greenLights[currentMovePoint].transform.position - car.transform.position; //get the direction
        car.transform.rotation = Quaternion.Slerp(car.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime); //slerp the rotation of the car to face the green light it is going towards

        car.transform.Translate(0, 0, Time.deltaTime * moveSpeed); //move the car forward by the movespeed
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
