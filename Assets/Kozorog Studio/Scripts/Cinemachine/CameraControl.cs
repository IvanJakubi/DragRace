using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public CarController carController;

    [Header("Game Cameras")]
    [SerializeField] private GameObject regularSpeedCamera;
    [SerializeField] private GameObject nitroSpeedCamera;

    [Header("Menu Cameras")]
    [SerializeField] private GameObject mainMenuCamera;
    [SerializeField] private GameObject shopMenuCamera;

    public void OnGameStart(EventMessage eventMessage)
    {
        mainMenuCamera.SetActive(false);
        regularSpeedCamera.SetActive(true);
    }
    
    public void ActivateGameCamera()
    {
        regularSpeedCamera.SetActive(true);
        nitroSpeedCamera.SetActive(false);
    }

    public void ActivateNitroCamera()
    {
        if (carController.gearRaised == false && carController.isDodging == false && carController.currentNitroMeter > 0f)
        {
            regularSpeedCamera.SetActive(false);
            nitroSpeedCamera.SetActive(true);
        }
    }

    public void EndReachedCamera()
    {

    }

    public void ActivateMenuCamera()
    {

    }

    public void ActivateShopCamera()
    {

    }
}
