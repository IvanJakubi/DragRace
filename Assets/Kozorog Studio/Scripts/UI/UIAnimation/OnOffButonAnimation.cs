using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButonAnimation : MonoBehaviour
{
    public bool isOn;
    public HapticSound hapticSound;

    [SerializeField] ScriptableEvent onVibrate;
    [SerializeField] Image onFill;
    [SerializeField] GameObject circle;
    [SerializeField] float reachPosition;
    [SerializeField] float speed;

    public enum HapticSound
    {
        Haptic,
        Sound
    }

    public void OnOffButton()
    {
        if (isOn == false)
        {
            isOn = true;

            if (hapticSound == HapticSound.Haptic)
                onVibrate.RaiseEvent(new EventMessage());
        }
        else
            isOn = false;

        AnimateButton();
    }

    private void AnimateButton()
    {
        if (isOn == true)
        {
            var turnOnButtonSequence = DOTween.Sequence()
                .Append(onFill.DOFillAmount(1, speed))
                .Join(circle.transform.DOLocalMoveX(reachPosition, speed));

            turnOnButtonSequence.SetEase(Ease.Linear);
        }
        else
        {
            var turnOffButtonSequence = DOTween.Sequence()
                    .Append(onFill.DOFillAmount(0, speed))
                    .Join(circle.transform.DOLocalMoveX(-reachPosition, speed));

            turnOffButtonSequence.SetEase(Ease.Linear);
        }
    }
}
