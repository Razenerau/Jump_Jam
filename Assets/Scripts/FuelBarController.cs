using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    public Image image;
    public static FuelBarController Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetFillAmount(float fuelAmount)
    {
        float totalFuel = PlayerFuel.Instance.MaxFuel;
        float percentage = fuelAmount / totalFuel;
        image.fillAmount = percentage;
    }
}
