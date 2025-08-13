using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject OtherDoor;
    public GameObject Player;

    public void Teleport()
    {
        if(Player == null)
        {
            Debug.Log("player not found");
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (OtherDoor == null)
        {
            SoundManager.PlaySound(SoundType.DOOR_LOCKED);
        }
        else
        {
            StartCoroutine(TeleportAfterDelay());
            Debug.Log("Teleported");
            
        }
        
    }

    private IEnumerator TeleportAfterDelay()
    {
        SoundManager.PlaySound(SoundType.DOOR_OPEN);
        PlayerController playerController = Player.GetComponent<PlayerController>();
        playerController.enabled = false;
        Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Player.GetComponent<PlayerModel>().IsGrounded = true;

        yield return new WaitForSeconds(1f); // Wait for 1 second
        Player.transform.position = OtherDoor.transform.position;
        playerController.enabled = true;
    }

}
