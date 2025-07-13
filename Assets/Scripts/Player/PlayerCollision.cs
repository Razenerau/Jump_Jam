using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) { 
        switch (collision.tag) {
            case "Death":
            {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);   
                break;
            }
            case "Finish":
            {
                    string nextLevel = collision.transform.GetComponent<Goal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                break;
            }
            case "Fuel":
            {
                    FuelData fuelData = collision.gameObject.GetComponent<FuelData>();
                    PlayerController playerController = gameObject.GetComponent<PlayerController>();

                    float fuelAmount = fuelData.FuelAmount;
                    playerController.AddFuel(fuelAmount);

                    SoundManager.PlaySound(SoundType.FUEL, (0.75f + fuelAmount/100));

                    Destroy(collision.gameObject);
                break;
            }
        }
    }
}
