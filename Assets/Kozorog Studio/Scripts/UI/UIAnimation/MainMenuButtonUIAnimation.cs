using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonUIAnimation : MonoBehaviour
{
    [SerializeField] private GameObject customizeButton;
    [SerializeField] private float customizeMoveX;

    // Start is called before the first frame update
    void Start()
    {
        float customizeStartingPos = customizeButton.transform.localPosition.x;

        var customizeButtonSequence = DOTween.Sequence()
            .Append(customizeButton.transform.DOLocalMoveX(customizeStartingPos - customizeMoveX, 1f))
            .Append(customizeButton.transform.DOLocalMoveX(customizeStartingPos, 1f));

        customizeButtonSequence.SetLoops(-1);
    }
}
