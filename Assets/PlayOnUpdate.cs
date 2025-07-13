using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayOnUpdate : StateMachineBehaviour
{
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private SoundType _sound;
    [SerializeField] private float _walkingInterval;
    [SerializeField] private float _runningInterval;
    [SerializeField][ReadOnly] private float _timeLeft = 0;
    private bool _flipVolume;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _timeLeft -= Time.deltaTime;
        float xVelocity = Mathf.Abs(animator.GetFloat("xVelocity"));

        if (xVelocity > 0 && _timeLeft <= 0)
        {
            float randomValue1 = UnityEngine.Random.Range(0.6f, 0.8f);
            float randomValue2 = UnityEngine.Random.Range(1.2f, 1.4f);
            _flipVolume = !_flipVolume;
            float volume = _flipVolume ? randomValue1 : randomValue2;

            if (xVelocity > 5)
            {
                _timeLeft = _runningInterval;
                SoundManager.PlaySound(_sound, volume);
            }
            else
            {
                _timeLeft = _walkingInterval;
                SoundManager.PlaySound(_sound, volume);
            }
        } 
    }
}
