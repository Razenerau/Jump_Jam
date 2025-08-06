using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public CinemachineView CinemachineView;

    private void OnTriggerEnter2D(Collider2D collision) { 
        switch (collision.tag) {
            case "Death":
            {
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);   

                    //SceneManager.LoadScene("LVL1_2");  
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

                    PuzzleController puzzleController = fuelData.PuzzleController;
                    puzzleController.SetResetActive(true);

                    Destroy(collision.gameObject);
                break;
            }
            case "CamTrigger":
            {
                    CameraTrigger cameraTrigger = collision.gameObject.GetComponent<CameraTrigger>();
                    PolygonCollider2D newCameraPath = cameraTrigger.CameraPath;
                    float newCameraSize = cameraTrigger.CameraSize;
                    CinemachineView.SetCameraPath(newCameraPath);
                    CinemachineView.SetSize(newCameraSize);
                break;
            }
        }
    }
}
