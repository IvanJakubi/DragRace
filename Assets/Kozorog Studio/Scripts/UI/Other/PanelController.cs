using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel, _menuPanel, _rewardPanel, _settingsMenu, _shopMenu;
    [SerializeField] private ScriptableEvent onRewardUpdateAmount;

    public void OnGameStart (EventMessage eventMessage)
    {
        ActivateGameMenu();
    }

    public void OnRewardMenuOpened(EventMessage eventMessage)
    {
        ActivateRewardMenu();
        onRewardUpdateAmount.RaiseEvent(new EventMessage());
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

    public void ActivateSettings()
    {
        _menuPanel.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        _menuPanel.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    public void ActivateShopMenu()
    {
        _menuPanel.SetActive(false);
        _shopMenu.SetActive(true);
    }

    public void CloseShopMenu()
    {
        _menuPanel.SetActive(true);
        _shopMenu.SetActive(false);
    }
}

