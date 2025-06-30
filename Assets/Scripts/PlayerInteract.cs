using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {
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
                float fuelAmount = fuelData.FuelAmount;
                PlayerFuel.Instance.AddFuel(fuelAmount);
                Destroy(collision.gameObject);
                    Debug.Log("Fuel Atdtet");
                break;
            }
        }
    }
}
