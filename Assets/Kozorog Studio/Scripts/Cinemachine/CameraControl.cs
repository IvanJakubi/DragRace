using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CarController carController;

    [Header("Game Cameras")]
    [SerializeField] private GameObject regularSpeedCamera;
    [SerializeField] private GameObject nitroSpeedCamera;
    [SerializeField] private GameObject endRewardCamera;

    [Header("Menu Cameras")]
    [SerializeField] private GameObject mainMenuCamera;
    [SerializeField] private GameObject shopMenuCamera;

    public void Start()
    {
        
    }

    public void OnGameStart(EventMessage eventMessage)
    {
        mainMenuCamera.SetActive(false);
        regularSpeedCamera.SetActive(true);
    }

    public void OnRewardEnd(EventMessage eventMessage)
    {
        endRewardCamera.SetActive(true);
        regularSpeedCamera.SetActive(false);
        nitroSpeedCamera.SetActive(false);
    }
    
    public void ActivateGameCamera()
    {
        if (!endRewardCamera.activeInHierarchy)
        {
            regularSpeedCamera.SetActive(true);
            nitroSpeedCamera.SetActive(false);
        }
    }

    public void ActivateNitroCamera()
    {
        if (carController.gearRaised == false && carController.isDodging == false && carController.currentNitroMeter > 0f)
        {
            regularSpeedCamera.SetActive(false);
            nitroSpeedCamera.SetActive(true);
        }
    }
}
