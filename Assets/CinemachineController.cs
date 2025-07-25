using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public GameObject Player;
    public CinemachineConfiner2D Confiner;
    public CinemachineVirtualCamera VirtualCamera;
    public List<PolygonCollider2D> CameraPathList;
    public List<float> ThreshholdXList;
    public List<float> SizeList;

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Player.transform.position.x;
        int cameraPathNum = 0;
        float cameraSize = 9;

        for (int i = 0; i < ThreshholdXList.Count; i++)
        {
            if(posX > ThreshholdXList[i])
            {
                cameraPathNum = i;
                cameraSize = SizeList[i];
            }
        }

        SetCameraPath(cameraPathNum);
        SetSize(cameraSize);
    }

    private void SetCameraPath(int num)
    {
        Confiner.m_BoundingShape2D = CameraPathList[num];  
    }

    private void SetSize(float size)
    {
        VirtualCamera.m_Lens.OrthographicSize = size;
    }
}
