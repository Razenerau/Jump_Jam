using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public PlayerControlsView PCW;
    public PlayerControlsData PCD;
    public CinemachineView CinemachineView;

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.tag) {
            case "Death":
                PlayerModel playerModel = GetComponent<PlayerModel>();
                if(playerModel.Spawnpoint != Vector2.zero)
                {
                    gameObject.transform.position = playerModel.Spawnpoint;
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else
                {
                    gameObject.transform.position = new Vector3(-29, -5.5f, 0);
                }
                
                break;
                
            case "Finish":
                
                    string nextLevel = collision.transform.GetComponent<Goal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                
            case "Fuel":
                
                    FuelData fuelData = collision.gameObject.GetComponent<FuelData>();
                    PlayerController playerController = gameObject.GetComponent<PlayerController>();

                    float fuelAmount = fuelData.FuelAmount;
                    playerController.AddFuel(fuelAmount);

                    SoundManager.PlaySound(SoundType.FUEL, (0.75f + fuelAmount / 100));

                    PuzzleController puzzleController = fuelData.PuzzleController;
                    puzzleController.SetResetActive(true);

                    Destroy(collision.gameObject);
                    break;
                
            case "CamTrigger":
                
                    CameraTrigger cameraTrigger = collision.gameObject.GetComponent<CameraTrigger>();
                    PolygonCollider2D newCameraPath = cameraTrigger.CameraPath;
                    float newCameraSize = cameraTrigger.CameraSize;
                    CinemachineView.SetCameraPath(newCameraPath);
                    CinemachineView.SetSize(newCameraSize);
                    break;
                
            case "Seeds":
                playerModel = gameObject.GetComponent<PlayerModel>();
                playerModel.SeedsCount++;
                Debug.Log(playerModel.SeedsCount);

                Destroy(collision.gameObject);
                break;
            
            case "Tutorial":

                TutorialModel tm = collision.gameObject.GetComponent<TutorialModel>();

                switch (tm.tutorialType)
                {
                    case TutorialModel.Tutorial.LeftRight:
                        PCW.SetControlsVisible(true);
                        break;
                    case TutorialModel.Tutorial.Jump:
                        PCW.SetSpaceVisible(true);
                        PCW.SetColor(PCD.Space_SP, Color.white);
                        PCW.SetSprite(PlayerControlsController.Sprites.Space);
                        PCD.IsJumpTutorial = true;
                        break;
                    case TutorialModel.Tutorial.Run:
                        PCW.SetSpaceVisible(true);
                        PCW.SetSprite(PlayerControlsController.Sprites.Shift);
                        break;
                    case TutorialModel.Tutorial.Interact:
                        PCW.SetEVisible(true);
                        break;
                    case TutorialModel.Tutorial.Fly:
                        PCD.IsDoubleJumpTutorial = true;
                        playerModel = gameObject.GetComponent<PlayerModel>();
                        StartCoroutine(StartFlyTutorial(playerModel));
                        break;
                }
                break;
            case "Checkpoint":
                CheckpointController checkpointController = collision.gameObject.GetComponent<CheckpointController>();
                playerModel = gameObject.GetComponent<PlayerModel>();

                playerModel.Spawnpoint = checkpointController.RespawnPoint.position;
                checkpointController.SetActive();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tutorial"))
        {
            TutorialModel tm = collision.gameObject.GetComponent<TutorialModel>();
            Debug.Log(tm.tag + "   " + tm.tutorialType);

            switch (tm.tutorialType)
            {
                case TutorialModel.Tutorial.LeftRight:
                    PCW.SetControlsVisible(false);
                    break;
                case TutorialModel.Tutorial.Jump:
                    PCW.SetSpaceVisible(false);
                    PCD.IsJumpTutorial = false;
                    break;
                case TutorialModel.Tutorial.Run:
                    PCW.SetSpaceVisible(false);
                    break;
                case TutorialModel.Tutorial.Interact:
                    PCW.SetEVisible(false);
                    break;
                case TutorialModel.Tutorial.Fly:
                    PCD.IsDoubleJumpTutorial = false;
                    PCW.SetSpaceVisible(false);
                    break;
            }
        }
    }

    private IEnumerator StartFlyTutorial(PlayerModel pm)
    {
        while (pm.CurrentFuel <= 0)
        {
            yield return new WaitForFixedUpdate();
        }
        PCW.SetSpaceVisible(true);
    }
}
