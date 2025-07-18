using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    public Image image;
    public static FuelBarController Instance;
    public PlayerModel playerModel;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        SetFillAmount(playerModel.CurrentFuel);
    }

    public void SetFillAmount(float fuelAmount)
    {
        float totalFuel = playerModel.MaxFuel;
        float percentage = fuelAmount / totalFuel;
        image.fillAmount = percentage;
    }
}
