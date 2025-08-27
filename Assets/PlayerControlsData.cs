using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsData : MonoBehaviour
{
    public bool IsArrowKeys = false;

    [Header("Sprite Renderers")]
    public SpriteRenderer Left_SP;
    public SpriteRenderer Right_SP;
    public SpriteRenderer Space_SP;
    public SpriteRenderer E_SP;

    [Header("Sprites")]
    public Sprite A;
    public Sprite D;
    public Sprite LeftArrow;
    public Sprite RightArrow;
    public Sprite E;
    public Sprite Space;
    public Sprite Shift;

    [Header("Variables")]
    public float PressedOffset;
    public bool IsJumpTutorial;
    public bool IsShiftGreen;
}
