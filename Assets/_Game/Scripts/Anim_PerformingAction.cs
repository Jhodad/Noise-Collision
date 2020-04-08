using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_PerformingAction : StateMachineBehaviour
{
    float percentage = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("combatTimeoutCurrentTime", animator.GetInteger("combatTimeoutTime"));
        animator.SetInteger("atkPhase", animator.GetInteger("atkPhase") + 1 );
        //Debug.Log("============= inicia : " + animatorStateInfo);
        animator.SetBool("EnteredAction", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("EnteredAction", false);
        animator.SetBool("combatTimeout", true);
        //Debug.Log("I finished with: " + percentage);

        animator.ResetTrigger("Guit_Atk_BasicSwing(Ground)_1");
        animator.ResetTrigger("Guit_Atk_BasicSwing(Ground)_2");
        animator.ResetTrigger("Guit_Atk_BasicSwing(Ground)_3");
        animator.ResetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_1");
        animator.ResetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_2");

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("EnteredAction", true);
        // Debug.Log("========MAX : " + animatorStateInfo.length);
        //Debug.Log("=======CURRENT : " + animatorStateInfo.normalizedTime);

        //get percent
        percentage = (animatorStateInfo.normalizedTime / animatorStateInfo.length ) *100;
       // Debug.Log("=======CURRENT PERCENT: " + percentage + "%");


      
        
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
