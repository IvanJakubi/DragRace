using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimatorController : MonoBehaviour
{
    public CarController CarController;

    [SerializeField] ScriptableEvent rewardEnd;

    public void OnRewardEnd()
    {
        rewardEnd.RaiseEvent(new EventMessage());
    }

    public void StopSkidMarks()
    {
        CarController.skidMarkRight.emitting = false;
        CarController.skidMarkLeft.emitting = false;
        CarController.smokeLeft.Stop();
        CarController.smokeRight.Stop();
    }
}
