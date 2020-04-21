using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLight : CarClass
{
    private bool lightpicked;
    private Circle circle;
    public static Transform target;

    private void Awake()
    {
        circle = GameObject.Find("circle").GetComponent<Circle>();
    }

    
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex); //run the onstart for the CarClass script 
        target = null;
        currentMovePoint = Random.Range(0, circle.greenLights.Count); //select a random green light
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(currentMovePoint > circle.greenLights.Count) //if the random number is outside the index of the green lights list
            currentMovePoint = Random.Range(0, circle.greenLights.Count); //select a random green light

        target = circle.greenLights[currentMovePoint].transform;

        if (target != null)
            animator.SetBool("move", true);
    }
}
