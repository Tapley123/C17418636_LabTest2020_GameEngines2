using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLight : StateMachineBehaviour
{
    GameObject car;
    int currentMovePoint;
    float closeDistance = 3.0f;
    float rotationSpeed = 1f, moveSpeed = 2f;
    private Circle circle;

    private void Awake()
    {
        circle = GameObject.Find("Trafic Light Manager").GetComponent<Circle>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        car = animator.gameObject; //gettin the car game object
        currentMovePoint = Random.Range(0, circle.greenLights.Count); //select a random green light
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (circle.greenLights.Count == 0)
            return; //if there are no green lights dont run

        if(Vector3.Distance(circle.greenLights[currentMovePoint].transform.position, car.transform.position) < closeDistance) //if the car has gotten within the close distance of the light
            currentMovePoint = Random.Range(0, circle.greenLights.Count); //select a random green light

        var direction = circle.greenLights[currentMovePoint].transform.position - car.transform.position; //get the direction
        car.transform.rotation = Quaternion.Slerp(car.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime); //slerp the rotation of the car to face the green light it is going towards

        car.transform.Translate(0, 0, Time.deltaTime * moveSpeed); //move the car forward by the movespeed
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
