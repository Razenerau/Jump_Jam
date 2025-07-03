using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetController : MonoBehaviour
{
    public PlayerModel PlayerModel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Grounded");
        PlayerModel.IsGrounded = true;
        PlayerModel.IsFalling = false;
        PlayerModel.IsJumping = false;
    }
}
