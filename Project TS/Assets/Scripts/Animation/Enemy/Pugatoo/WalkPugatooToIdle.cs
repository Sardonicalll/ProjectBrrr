using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPugatooToIdle : StateMachineBehaviour {
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var ai = animator.GetComponent<PugatooAI>();
        if (!ai.HasMoved())
        {
            animator.SetBool("walking", false);
        }
    }
}
