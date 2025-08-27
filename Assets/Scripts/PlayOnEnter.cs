using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnter : StateMachineBehaviour
{
    [SerializeField] private SoundType _sound;
    [SerializeField] private bool _hasRequirements = false;
    [SerializeField] private float _requiredValue = 0;
    [SerializeField] private string _requiredParameterName = "";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float parameter = 999f;
        if (_hasRequirements) parameter = animator.GetFloat(_requiredParameterName);

        // Optional: Use requirements to conditionally play the sound
        if (!_hasRequirements || parameter < _requiredValue)
        {
            SoundManager.PlaySound(_sound);
        }

    }
}
