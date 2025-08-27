using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsView : MonoBehaviour
{
    public PlayerControlsController PCC;
    public PlayerControlsData PCD;
    public void SetSprite(PlayerControlsController.Sprites spriteName)
    {
        switch (spriteName)
        {
            case PlayerControlsController.Sprites.A:
                PCD.Left_SP.sprite = PCD.A;
                break;
            case PlayerControlsController.Sprites.D:
                PCD.Right_SP.sprite = PCD.D;
                break;
            case PlayerControlsController.Sprites.LeftArrow:
                PCD.Left_SP.sprite = PCD.LeftArrow;
                break;
            case PlayerControlsController.Sprites.RightArrow:
                PCD.Right_SP.sprite = PCD.RightArrow;
                break;
            case PlayerControlsController.Sprites.Space:
                PCD.Space_SP.sprite = PCD.Space;
                break;
            case PlayerControlsController.Sprites.Shift:
                PCD.Space_SP.sprite = PCD.Shift;
                break;
        }
    }

    public void SetColor(SpriteRenderer sp, Color color)
    {
        sp.color = color;
    }

    public void SetPressed(GameObject button, bool isPressed)
    {
        if (isPressed && button.tag != "Pressed")
        {
            button.tag = "Pressed";
            button.transform.localPosition = new Vector2(button.transform.localPosition.x,
                                                         button.transform.localPosition.y - PCD.PressedOffset);
        }
        else if(!isPressed && button.tag == "Pressed")
        {
            button.tag = "Untagged";
            button.transform.localPosition = new Vector2(button.transform.localPosition.x,
                                                         button.transform.localPosition.y + PCD.PressedOffset);
        }
        
    }

    public void SetControlsVisible(bool isVisible)
    {
        PCD.Left_SP.gameObject.SetActive(isVisible);
        PCD.Right_SP.gameObject.SetActive(isVisible);
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
