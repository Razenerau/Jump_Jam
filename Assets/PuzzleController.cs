using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public PlayerController PlayerController;
    public List<GameObject> PuzzleObjects;
    public List<GameObject> ResettableObjects = new();

    void Start()
    {
        foreach (var originalObject in PuzzleObjects)
        {
            GameObject clone = Instantiate(originalObject, originalObject.transform.position,
                                           Quaternion.identity, this.transform);

            clone.SetActive(true);
            ResettableObjects.Add(clone);

            originalObject.SetActive(false);
        }
    }

    public void ResetPuzzle()
    {
        PlayerController.SetFuel(0);
        ResettableObjects.Clear();
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var originalObject in PuzzleObjects)
        {
            GameObject clone = Instantiate(originalObject, originalObject.transform.position,
                                           Quaternion.identity, this.transform);

            clone.SetActive(true);
            ResettableObjects.Add(clone);

            originalObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetPuzzle();  
        }
    }
}
