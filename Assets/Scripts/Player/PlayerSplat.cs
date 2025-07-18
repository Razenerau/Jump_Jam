using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplat : MonoBehaviour
{
    public void SetSplat()
    {
        PlayerModel playerModel = GetComponent<PlayerModel>();
        playerModel.IsSplat = true;

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        StartCoroutine(SplatTime());
    }

    private IEnumerator SplatTime()
    {
        yield return new WaitForEndOfFrame();
        PlayerController controller = GetComponent<PlayerController>();
        //controller.enabled = false;

        PlayerModel playerModel = GetComponent<PlayerModel>();
        yield return new WaitForSeconds(playerModel.SplatTime);
        playerModel.SplatTime = (playerModel.SplatTime / 2f) > 0.5f ? (playerModel.SplatTime / 2f) : 0.5f;
        playerModel.IsSplat = false;

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        //controller.enabled = true;
    }
}
