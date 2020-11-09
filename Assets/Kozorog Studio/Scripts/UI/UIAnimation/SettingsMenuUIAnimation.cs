using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuUIAnimation : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public void ScaleSettings()
    {
        var settingsMenuSequence = DOTween.Sequence()
            .Append(settingsPanel.transform.DOScale(1f, 0.5f));

        settingsMenuSequence.SetEase(Ease.Linear);
    }

    public void ScaleBackSettings()
    {
        var settingsMenuDescaleSequence = DOTween.Sequence()
            .Append(settingsPanel.transform.DOScale(0.9f, 0.5f));

        settingsMenuDescaleSequence.SetEase(Ease.Linear);
    }
}
