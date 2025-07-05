using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplat : MonoBehaviour
{
    public void SetSplat()
    {
        PlayerModel playerModel = GetComponent<PlayerModel>();
        playerModel.IsSplat = true;
        
        

        StartCoroutine(SplatTime());
    }

    private IEnumerator SplatTime()
    {
        yield return new WaitForEndOfFrame();
        PlayerController controller = GetComponent<PlayerController>();
        controller.enabled = false;

        PlayerModel playerModel = GetComponent<PlayerModel>();
        Debug.Log("No Movenment");
        yield return new WaitForSeconds(playerModel.SplatTime);
        playerModel.IsSplat = false;

        controller.enabled = true;
    }
}
