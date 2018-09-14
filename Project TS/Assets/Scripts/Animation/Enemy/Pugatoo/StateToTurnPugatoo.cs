using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateToTurnPugatoo : StateMachineBehaviour {
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var ai = animator.GetComponent<PugatooAI>();
        if (ai.HasRotated())
        {
            animator.SetBool("turning", true);
        }
    }
}
