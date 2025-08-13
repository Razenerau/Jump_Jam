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

        if (OtherDoor != null)
        {
            Debug.Log("Teleported");
            Player.transform.position = OtherDoor.transform.position;
            SoundManager.PlaySound(SoundType.DOOR_OPEN);
        }
        else
        {
            SoundManager.PlaySound(SoundType.DOOR_LOCKED);
        }
        
    }
}
