using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        SetControls(PCD.IsArrowKeys);
    }

    private void Update()
    {
        CheckLeftButton();
        CheckRightButton();
        CheckSpace();
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

    private void CheckSpace()
    {
        
        KeyCode keyCode1 = KeyCode.LeftShift;
        KeyCode keyCode2 = KeyCode.RightShift;

        if (PCD.IsJumpTutorial)
        {
            keyCode1 = KeyCode.Space;
            keyCode2 = KeyCode.Space;
        }

        if (Input.GetKeyDown(keyCode1) || Input.GetKeyDown(keyCode2))
        {
            PCW.SetColor(PCD.Space_SP, Color.green);
            PCW.SetPressed(PCD.Space_SP.gameObject, true);
        }
        if (Input.GetKeyUp(keyCode1) || Input.GetKeyUp(keyCode2))
        {
            PCW.SetColor(PCD.Space_SP, Color.white);
            PCW.SetPressed(PCD.Space_SP.gameObject, false);
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

    //-------------------------------------------------------
    //              Trigger Handling
    //--------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject + " entered collision");
        if(collision.CompareTag("Tutorial"))
        {
            TutorialModel tm = collision.gameObject.GetComponent<TutorialModel>();
            
            switch (tm.tutorialType)
            {
                case TutorialModel.Tutorial.LeftRight: 
                    PCW.SetControlsVisible(true);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject + " left collision");
        if (collision.CompareTag("Tutorial"))
        {
            TutorialModel tm = collision.gameObject.GetComponent<TutorialModel>();

            switch (tm.tutorialType)
            {
                case TutorialModel.Tutorial.LeftRight:
                    PCW.SetControlsVisible(false);
                    break;
            }
        }
    }
}
