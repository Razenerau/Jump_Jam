using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialModel : MonoBehaviour
{
    public enum Tutorial
    {
        LeftRight,
        Jump,
        Run,
        Interact
    }

    public Tutorial tutorialType;
}
