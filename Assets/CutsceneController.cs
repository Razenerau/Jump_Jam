using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject UICanvas;
    public GameObject PauseCanvas;

    [Header("Scenes")]
    public List<Sprite> Scenes;
    public List<Sprite> GoodEndingScenes;
    public List<Sprite> BadEndingScenes;

    [Header("Variables")]
    public Image SpaceButton;
    public PlayerModel PlayerModel;
    public Image Display;
    public bool IsActive = false;
    public int CurrentScene = 0;
    public bool IsGoodEnding = false;

    [Header("End Screen")]
    public Button ReloadButton;
    public TextMeshProUGUI EndingText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        
        PlayerModel = collision.gameObject.GetComponent<PlayerModel>();
        if(PlayerModel.SeedsCount < 3)
        {
            IsGoodEnding = false;
            Scenes = BadEndingScenes;
        }
        else
        {
            IsGoodEnding = true;
            Scenes = GoodEndingScenes;
        }
        PauseMenuController.IsPaused = true;
        Display.gameObject.SetActive(true);
        SpaceButton.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
        Display.sprite = Scenes[0];
        IsActive = true;
    }

    private void Awake()
    {
        EndingText.gameObject.SetActive(false);
        ReloadButton.gameObject.SetActive(false);
        Display.gameObject.SetActive(false);
        SpaceButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (IsActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space)))
        {
            if(Scenes.Count - 1 > CurrentScene)
            {
                CurrentScene++;
                Display.sprite = Scenes[CurrentScene];
                SpaceButton.gameObject.SetActive(false);
            }
            else
            {
                LoadEndScreen();
            }
        }
    }

    private void LoadEndScreen()
    {
        if(IsGoodEnding)
        {
            EndingText.SetText("Good Ending");
        }
        else
        {
            EndingText.SetText("Doomed Ending");
        }

        EndingText.gameObject.SetActive(true);
        ReloadButton.gameObject.SetActive(true);
    }
}
