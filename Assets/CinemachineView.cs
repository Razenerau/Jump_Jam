using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineView : MonoBehaviour
{
    public CinemachineConfiner2D Confiner;
    public CinemachineVirtualCamera VirtualCamera;

    public void SetCameraPath(PolygonCollider2D cameraPath)
    {
        Confiner.m_BoundingShape2D = cameraPath;
    }

    public void SetSize(float size)
    {
        VirtualCamera.m_Lens.OrthographicSize = size;
    }
}
