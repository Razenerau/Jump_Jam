using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator Animator;
    public static PlayerAnim Instance;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
