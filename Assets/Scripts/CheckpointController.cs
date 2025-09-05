using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Transform RespawnPoint;
    public Collider2D CheckPointCollider;
    public SpriteRenderer SpriteRenderer;

    public void SetActive()
    {
        SpriteRenderer.color = Color.green;
        CheckPointCollider.enabled = false;
    }
}
