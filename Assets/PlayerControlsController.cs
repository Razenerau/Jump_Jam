using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsController : MonoBehaviour
{
    public PlayerControlsData PCD;

    public enum Sprites
    {
        A,
        D,
        LeftArrow,
        RightArrow,
        Space,
        Shift
    }

    void Start()
    {
        SetControls(PCD.isArrowKeys);
    }

    public void SetControls(bool isArrowKeys)
    {
        if (isArrowKeys)
        {
            SetSprite(Sprites.LeftArrow);
            SetSprite(Sprites.RightArrow);
        }
        else
        {
            SetSprite(Sprites.A);
            SetSprite(Sprites.D);
        }
    } 

    public void SetSprite(Sprites spriteName)
    {
        switch (spriteName)
        {
            case Sprites.A:
                PCD.Left_SP.sprite = PCD.A;
                break;
            case Sprites.D:
                PCD.Right_SP.sprite = PCD.D;
                break;
            case Sprites.LeftArrow:
                PCD.Left_SP.sprite = PCD.LeftArrow;
                break;
            case Sprites.RightArrow:
                PCD.Right_SP.sprite = PCD.RightArrow;
                break;
            case Sprites.Space:
                PCD.Space_SP.sprite = PCD.Space;
                break;
            case Sprites.Shift:
                PCD.Space_SP.sprite = PCD.Shift;
                break;
        }
    }

    public void SetControlsVisible(bool isVisible)
    {
        PCD.Left_SP.gameObject.SetActive(isVisible);
    }

    public void SetEVisible(bool isVisible)
    {
        PCD.Left_SP.gameObject.SetActive(isVisible);
    }

    public void SetSpaceVisible(bool isVisible)
    {
        PCD.Left_SP.gameObject.SetActive(isVisible);
    }

}
