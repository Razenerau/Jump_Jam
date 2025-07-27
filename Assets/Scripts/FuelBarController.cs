using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    public Image image;
    public static FuelBarController Instance;
    public PlayerModel playerModel;
    public Image Arrow;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        SetFillAmount(playerModel.CurrentFuel);
    }

    public void SetFillAmount(float fuelAmount)
    {
        Debug.Log("Filled " + gameObject.name);
        float totalFuel = playerModel.MaxFuel;
        float percentage = fuelAmount / totalFuel;
        image.fillAmount = (0.25f * percentage);

        if(Arrow != null)
        {
            RectTransform rectTransform = Arrow.GetComponent<RectTransform>();
            float newRotation = (92.9f * percentage) - 45.2f;
            rectTransform.rotation = Quaternion.Euler(new Vector3 (0, 0, newRotation));
        }
    }
}
