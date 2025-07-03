using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            Debug.Log("Grounded");
            PlayerModel.IsGrounded = true;
            PlayerModel.IsFalling = false;
            PlayerModel.IsJumping = false;
        

    }
}
