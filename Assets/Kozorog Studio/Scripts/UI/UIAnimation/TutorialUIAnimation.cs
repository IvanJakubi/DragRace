using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIAnimation : MonoBehaviour
{
    [Header("Dodge Left Tutorial Animation")]
    [SerializeField] private GameObject fingerLeft;
    [SerializeField] private float lFingerXLeft;
    [SerializeField] private float lFingerXRight;
    [SerializeField] private float lFingerScaleMin;
    [SerializeField] private float lFingerMoveSpeedLeft;
    [SerializeField] private float lFingerMoveSpeedRight;
    [SerializeField] private float lFingerRotateLeft;

    [Header("Dodge Right Tutorial Animation")]
    [SerializeField] private GameObject fingerRight;
    [SerializeField] private float rFingerXLeft;
    [SerializeField] private float rFingerXRight;
    [SerializeField] private float rFingerScaleMin;
    [SerializeField] private float rFingerMoveSpeedLeft;
    [SerializeField] private float rFingerMoveSpeedRight;
    [SerializeField] private float rFingerRotateRight;

    [Header("Change Gear Tutorial Animation")]
    [SerializeField] private GameObject fingerUp;
    [SerializeField] private float fingerYDown;
    [SerializeField] private float fingerYUp;
    [SerializeField] private float fingerScaleMin;
    [SerializeField] private float fingerMoveSpeedUp;
    [SerializeField] private float fingerMoveSpeedDown;

    [Header("Activate Nitro Tutorial Animation")]
    [SerializeField] private GameObject fingerHold;
    [SerializeField] private Image circleTap;
    [SerializeField] private float hFingerScaleMin;
    [SerializeField] private float hFingerScaleSpeed;
    [SerializeField] private float circleTapScaleMin;
    [SerializeField] private float circleTapScaleMax;
    [SerializeField] private float circleScaleSpeed;


    // Start is called before the first frame update
    void Start()
    {
        var dodgeLeftTutSequence = DOTween.Sequence()
            .Append(fingerLeft.transform.DOScale(lFingerScaleMin, lFingerMoveSpeedLeft))
            .Join(fingerLeft.transform.DOLocalMoveX(lFingerXLeft, lFingerMoveSpeedLeft))
            .Join(fingerLeft.transform.DOLocalRotate(new Vector3(0f,0f,lFingerRotateLeft), lFingerMoveSpeedLeft))
            .Append(fingerLeft.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), lFingerMoveSpeedLeft))
            .Append(fingerLeft.transform.DOScale(1f, lFingerMoveSpeedRight))
            .Join(fingerLeft.transform.DOLocalMoveX(lFingerXRight, lFingerMoveSpeedRight));

        var dodgeRightTutSequence = DOTween.Sequence()
            .Append(fingerRight.transform.DOScale(rFingerScaleMin, rFingerMoveSpeedRight))
            .Join(fingerRight.transform.DOLocalMoveX(rFingerXRight, rFingerMoveSpeedRight))
            .Join(fingerRight.transform.DOLocalRotate(new Vector3(0f, 0f, rFingerRotateRight), rFingerMoveSpeedRight))
            .Append(fingerRight.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), rFingerMoveSpeedRight))
            .Append(fingerRight.transform.DOScale(1f, rFingerMoveSpeedLeft))
            .Join(fingerRight.transform.DOLocalMoveX(rFingerXLeft, rFingerMoveSpeedLeft));

        var changeGearTutSequence = DOTween.Sequence()
            .Append(fingerUp.transform.DOScale(fingerScaleMin, fingerMoveSpeedUp))
            .Append(fingerUp.transform.DOLocalMoveY(fingerYUp, fingerMoveSpeedUp))
            .Append(fingerUp.transform.DOScale(1f, fingerMoveSpeedDown))
            .Join(fingerUp.transform.DOLocalMoveY(fingerYDown, fingerMoveSpeedDown));

        var activateNitroTutSequence = DOTween.Sequence()
            .Append(fingerHold.transform.DOScale(hFingerScaleMin, hFingerScaleSpeed))
            .Append(circleTap.DOFade(1f, circleScaleSpeed))
            .Join(circleTap.transform.DOScale(circleTapScaleMax, circleScaleSpeed))
            .Append(circleTap.DOFade(0f, circleScaleSpeed))
            .Append(circleTap.transform.DOScale(circleTapScaleMin, circleScaleSpeed))
            .Join(fingerHold.transform.DOScale(1f, hFingerScaleSpeed));

        dodgeLeftTutSequence.SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        dodgeRightTutSequence.SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        changeGearTutSequence.SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        activateNitroTutSequence.SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
