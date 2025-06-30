using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    public static PlayerFuel Instance;
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
        Debug.Log(_fuel);
    }

    public float GetFuel() { return _fuel; }
    public void AddFuel(float num) { _fuel += num; }

}
