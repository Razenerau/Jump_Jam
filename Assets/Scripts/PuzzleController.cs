using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject ResetButton;
    public PlayerController PlayerController;
    public TutorialModel TutorialModel;

    [Header("Puzzle Componets")]
    public PuzzleController OtherPuzzle;
    public List<GameObject> PuzzleObjects;                  //Loaded in the editor
    public List<GameObject> ResettableObjects = new();      //Filled with clones of puzzleObjects

    [Header("Variables")]
    public float ResetFuelTo = 0;
    public bool IsActive = false;

    void Awake()
    {
        TutorialModel.tutorialType = TutorialModel.Tutorial.None;

        SetResetActive(false);
        InitializeResettableObjects();
    }

    private void InitializeResettableObjects()
    {
        foreach (var originalObject in PuzzleObjects)
        {
            GameObject clone = Instantiate(originalObject, originalObject.transform.position,
                                           Quaternion.identity, this.transform);

            clone.SetActive(true);
            ResettableObjects.Add(clone);

            FuelData fuelData = clone.GetComponent<FuelData>();
            if (fuelData != null)
            {
                fuelData.PuzzleController = this;
            }

            originalObject.SetActive(false);
        }
    }

    public void ResetPuzzle()
    {
        if (!IsActive) return;
        if(OtherPuzzle != null)
        {
            OtherPuzzle.ResetPuzzle();
        }

        PlayerController.SetFuel(ResetFuelTo);
        ResettableObjects.Clear();
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        InitializeResettableObjects();
        SetResetActive(false);
    }

    public void SetResetActive(bool isActive)
    {
        IsActive = isActive;

        SpriteRenderer spriteRenderer = ResetButton.GetComponent<SpriteRenderer>();

        switch (isActive)
        {
            case true:
                TutorialModel.tutorialType = TutorialModel.Tutorial.Interact;
                spriteRenderer.color = Color.white;
                break;

            case false:
                TutorialModel.tutorialType = TutorialModel.Tutorial.None;
                spriteRenderer.color = Color.gray;
                break;
        }
    }
}
