using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel, _menuPanel; 

    public void OnGameStart (EventMessage eventMessage)
    {
        ActivateGameMenu();
    }

    public void ActivateGameMenu()
    {
        _gamePanel.SetActive(true);
        _menuPanel.SetActive(false);
    }
}

