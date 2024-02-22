using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera m_playerCamera;
    
    public void SetPlayerCameraFollow()
    {
        m_playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
        m_playerCamera.Follow = PlayerController.Instance.transform;
    }
}
