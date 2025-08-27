using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsInRange;
    public KeyCode InteractKey;
    public KeyCode AltInteractKey;
    public UnityEvent InteractAction;

    private void Update()
    {
        if (IsInRange && (Input.GetKeyDown(InteractKey) || Input.GetKeyDown(AltInteractKey)))
        {
            InteractAction.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
        }
    }
}
