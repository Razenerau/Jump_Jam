using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public List<Sprite> Scenes;
    public List<Sprite> GoodEndingScenes;
    public List<Sprite> BadEndingScenes;

    public Image Display;
    public bool IsActive = false;
    public int CurrentScene = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Display.gameObject.SetActive(true);
        Display.sprite = Scenes[0];
    }

    private void Update()
    {
        if (IsActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            CurrentScene++;
            Display.sprite = Scenes[CurrentScene];
        }
    }
}
