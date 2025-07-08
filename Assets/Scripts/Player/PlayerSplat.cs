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
        rigidbody2D.isKinematic = true;

        StartCoroutine(SplatTime());
    }

    private IEnumerator SplatTime()
    {
        yield return new WaitForEndOfFrame();
        PlayerController controller = GetComponent<PlayerController>();
        controller.enabled = false;

        PlayerModel playerModel = GetComponent<PlayerModel>();
        yield return new WaitForSeconds(playerModel.SplatTime);
        playerModel.IsSplat = false;

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = false;

        controller.enabled = true;
    }
}
