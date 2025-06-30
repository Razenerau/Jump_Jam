using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    public static PlayerFuel Instance;
    public float MaxFuel = 100f;
    [SerializeField] private float _fuel = 100;
    [SerializeField] private float _fuelDepletion = 0.1f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void DecreseFuel()
    {
        _fuel -= _fuelDepletion;
        FuelBarController.Instance.SetFillAmount(_fuel);
    }

    public float GetFuel() { return _fuel; }
    public void AddFuel(float num)
    {
       //Debug.Log($"num: {num},   fuel {_fuel}");
        float newFuel = _fuel + num;
        if (newFuel >= MaxFuel) _fuel = MaxFuel;
        else _fuel += num;
        //Debug.Log($"newfuel {_fuel}");
        FuelBarController.Instance.SetFillAmount(_fuel);

    }

}
