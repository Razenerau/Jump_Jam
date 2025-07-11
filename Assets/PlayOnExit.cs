using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnExit : StateMachineBehaviour
{
    [SerializeField] private SoundType _sound;

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(_sound);
    }
}
