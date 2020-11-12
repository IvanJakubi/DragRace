using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimatorController : MonoBehaviour
{
    public CarController carController;

    [SerializeField] ScriptableEvent rewardEndReached;

    public void OnRewardEnd()
    {
        rewardEndReached.RaiseEvent(new EventMessage());
    }

    public void StopSkidMarks()
    {
        carController.skidMarkRight.emitting = false;
        carController.skidMarkLeft.emitting = false;
        carController.smokeLeft.Stop();
        carController.smokeRight.Stop();
    }
}
