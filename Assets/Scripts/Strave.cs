using UnityEngine;

public class Strave : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("StraveDirection", 0);
    }
}
