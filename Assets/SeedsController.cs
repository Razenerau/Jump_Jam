using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsController : MonoBehaviour
{
    public Transform sr1;
    public Transform sr2;
    public Transform sr3;

    public float TimeElapsed = 0;
    public float Speed = 2;
    public float Radius = 1;
    public float CurrentRadius = 1;
    public bool IsConstRadius = false;

    private void FixedUpdate()
    {

        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= 2 * (Mathf.PI) / Speed) TimeElapsed = 0;

        RotateObject(sr1, 0);
        RotateObject(sr2, 2 * Mathf.PI / 3);
        RotateObject(sr3, 4 * Mathf.PI / 3);

    }

    private void RotateObject(Transform t, float offset)
    {
        if (!IsConstRadius)
        {
            CurrentRadius = Radius * Mathf.Sin((TimeElapsed) * Speed);
        }
        else
        {
            CurrentRadius = Radius;
        }

        float x = CurrentRadius * Mathf.Cos((TimeElapsed + offset) * Speed);
        float y = CurrentRadius * Mathf.Sin((TimeElapsed + offset) * Speed);

        Vector2 newPos = new Vector2(transform.position.x + x, transform.position.y + y);
        t.position = newPos;
    }
}
