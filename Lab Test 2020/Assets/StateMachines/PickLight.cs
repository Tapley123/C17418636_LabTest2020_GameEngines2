using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLight : CarClass
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
        currentMovePoint = Random.Range(0, circle.greenLights.Count); //select a random green light
        animator.SetTrigger("MoveToLight");
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
