using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIAnimation : MonoBehaviour
{
    [SerializeField] private GameObject crownGlow;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float scaleSpeed;

    // Update is called once per frame
    void Update()
    {
        crownGlow.transform.DOLocalRotate(new Vector3(0,0,360),rotationSpeed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear).SetRelative();
    }

}
