using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject OtherDoor;
    public GameObject Player;
    public float TeleportTime = 0.5f;

    [Header("Sprites")]
    public Sprite OpenDoorSprite;
    public Sprite ClosedDoorSprite;

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
        }
        
    }

    private IEnumerator TeleportAfterDelay()
    {
        SetDoorOpen(true);

        SoundManager.PlaySound(SoundType.DOOR_OPEN);
        PlayerController playerController = Player.GetComponent<PlayerController>();
        playerController.enabled = false;
        Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //Player.GetComponent<Animator>().SetBool("isGrounded") = true;

        yield return new WaitForSeconds(TeleportTime); // Wait for 1 second
        Player.transform.position = OtherDoor.transform.position;
        playerController.enabled = true;

        SetDoorOpen(false);
    }

    private void SetDoorOpen(bool isOpen)
    {
        SpriteRenderer doorSpriteRenderer =  gameObject.GetComponentInChildren<SpriteRenderer>();
        
        if (isOpen)
        {
            doorSpriteRenderer.sprite = OpenDoorSprite;
        }
        else
        {
            doorSpriteRenderer.sprite = ClosedDoorSprite;
        }
    }
}
