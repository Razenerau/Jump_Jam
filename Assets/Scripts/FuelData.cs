using UnityEngine;

public class FuelData : MonoBehaviour
{
    public PuzzleController PuzzleController;
    public float FuelAmount = 20f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
        }
    }
}
