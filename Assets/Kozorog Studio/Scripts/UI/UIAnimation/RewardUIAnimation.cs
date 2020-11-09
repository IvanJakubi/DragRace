using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardUIAnimation : MonoBehaviour
{
    [SerializeField] private GameObject crownGlow;
    [SerializeField] private GameObject multipierButton;
    [SerializeField] private TextMeshProUGUI noButtonText;

    [Header("Crown Glow")]
    [SerializeField] private float rotationCrownSpeed;
    [SerializeField] private float scaleCrownSpeed;
    [SerializeField] private Vector3 originalCrownScale;
    [Range(0f,0.5f)]
    [SerializeField] private float scaleCrownStrength;

    [Header("Multiplier Button")]
    [SerializeField] private float scaleButtonSpeed;
    [SerializeField] private Vector3 originalButtonScale;
    [Range(0f, 0.5f)]
    [SerializeField] private float scaleButtonStrengthMax;
    [SerializeField] private float scaleButtonStrengthMid;

    [Header("No Thanks Button")]
    [SerializeField] private float waitTime;

    void Start()
    {
        originalCrownScale = crownGlow.transform.localScale;
        originalButtonScale = multipierButton.transform.localScale;

        crownGlow.transform.DOLocalRotate(new Vector3(0, 0, 360), rotationCrownSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).SetRelative();

        var sequenceCrownGlow = DOTween.Sequence()
            .Append(crownGlow.transform.DOScale(new Vector3(originalCrownScale.x + scaleCrownStrength, originalCrownScale.y + scaleCrownStrength, originalCrownScale.z + scaleCrownStrength), scaleCrownSpeed))
            .Append(crownGlow.transform.DOScale(originalCrownScale, scaleCrownSpeed));

        var sequenceMultiplerButton = DOTween.Sequence()
            .Append(multipierButton.transform.DOScale(new Vector3(originalButtonScale.x + scaleButtonStrengthMax, originalButtonScale.y + scaleButtonStrengthMax, originalButtonScale.z + scaleButtonStrengthMax), scaleButtonSpeed))
            .Append(multipierButton.transform.DOScale(new Vector3(originalButtonScale.x + scaleButtonStrengthMid, originalButtonScale.y + scaleButtonStrengthMid, originalButtonScale.z + scaleButtonStrengthMid), scaleButtonSpeed))
            .Append(multipierButton.transform.DOScale(new Vector3(originalButtonScale.x + scaleButtonStrengthMax, originalButtonScale.y + scaleButtonStrengthMax, originalButtonScale.z + scaleButtonStrengthMax), scaleButtonSpeed))
            .Append(multipierButton.transform.DOScale(originalButtonScale, scaleButtonSpeed));

        var sequenceButtonAlpha = DOTween.Sequence()
            .AppendInterval(waitTime)
            .Append(noButtonText.DOFade(1f, 2f));

        sequenceCrownGlow.SetLoops(-1, LoopType.Restart);
        sequenceMultiplerButton.SetLoops(-1, LoopType.Restart);
    }

}
