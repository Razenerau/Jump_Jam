using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsController : MonoBehaviour
{
    public PlayerControlsData PCD;
    public PlayerControlsView PCW;

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

    private void Update()
    {
        CheckLeftButton();
        CheckRightButton();
    }

    private void CheckRightButton()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PCW.SetColor(PCD.Right_SP, Color.green);
            PCW.SetPressed(PCD.Right_SP.gameObject, true);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PCW.SetColor(PCD.Right_SP, Color.white);
            PCW.SetPressed(PCD.Right_SP.gameObject, false);
        }
    }

    private void CheckLeftButton()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PCW.SetColor(PCD.Left_SP, Color.green);
            PCW.SetPressed(PCD.Left_SP.gameObject, true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PCW.SetColor(PCD.Left_SP, Color.white);
            PCW.SetPressed(PCD.Left_SP.gameObject, false);
        }
    }

    public void SetControls(bool isArrowKeys)
    {
        if (isArrowKeys)
        {
            PCW.SetSprite(Sprites.LeftArrow);
            PCW.SetSprite(Sprites.RightArrow);
        }
        else
        {
            PCW.SetSprite(Sprites.A);
            PCW.SetSprite(Sprites.D);
        }
    } 

    

}
