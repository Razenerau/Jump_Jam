using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnter : StateMachineBehaviour
{
    [SerializeField] private SoundType _sound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(_sound);
    }
}
