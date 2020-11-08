using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel, _menuPanel, _rewardPanel; 

    public void OnGameStart (EventMessage eventMessage)
    {
        ActivateGameMenu();
    }

    public void OnReward(EventMessage eventMessage)
    {
        ActivateRewardMenu();
    }

    public void ActivateGameMenu()
    {
        _gamePanel.SetActive(true);
        _menuPanel.SetActive(false);
    }

    public void ActivateRewardMenu()
    {
        _rewardPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }
}

