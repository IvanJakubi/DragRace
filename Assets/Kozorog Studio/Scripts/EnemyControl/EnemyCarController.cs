using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    #region Private Variables
    private bool _usingNitro = false;
    private float _currentNitroAcceleration;

    #endregion

    #region Public Variables
    [Header("Speed Array")]
    [Range(0f, 1f)]
    public float[] acceleration;
    public float[] maxSpeed;

    [Header("Nitro Array")]
    public float[] maxSpeedNitro;
    [Range(0.5f, 2f)]
    public float nitroAcceleration;
    [Range(0f, 1f)]
    public float nitroMeterConsumption;

    [Header("Car Status")]
    [Range(0, 5)]
    public int gear;
    public float currentSpeed;
    public float currentNitroMeter;

    [Header("Components")]
    public TrailRenderer skidMarkRight;
    public TrailRenderer skidMarkLeft;
    public Animator carAnimator;

    [Header("Particles")]
    public ParticleSystem speedParticle;
    public ParticleSystem nitroFlameRight;
    public ParticleSystem nitroFlameLeft;
    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;
    #endregion    

    #region Event Messages
    public void OnDodgeLeft(EventMessage eventMessage)
    {
            DodgeLeft();
    }

    public void OnDodgeRight(EventMessage eventMessage)
    {
            DodgeRight();
    }

    public void OnGearUp(EventMessage eventMessage)
    {
        RaiseGear();
    }

    public void OnNitroActivated(EventMessage eventMessage)
    {
        StartCoroutine(ActivateNitro());
    }

    public void OnCollisionCalled(EventMessage eventMessage)
    {
        CollisionSlowCar();
    }

    public void OnEndReached(EventMessage eventMessage)
    {
        carAnimator.Play("EndDrift");
        DodgeActivate();
    }
    #endregion

    #region Public functions
    //If the PlayerMovementState is Racing (PathFollower script), this functions runs on loop
    /// <summary>
    /// Accelerates the speed of the car, acceleration is increased if the player activates nitro
    /// </summary>
    public void AccelerateCar()
    {
        if (_usingNitro == false)
        {
            currentSpeed += acceleration[gear];

            if (currentSpeed > maxSpeed[gear])
            {
                currentSpeed -= acceleration[gear] * 2;
            }
        }
        else
        {
            currentSpeed += acceleration[gear] + _currentNitroAcceleration;
            DepleteNitroMeter();

            if (currentSpeed > maxSpeedNitro[gear])
            {
                currentSpeed = maxSpeedNitro[gear];
            }
        }
    }

    //If the PlayerMovementState is Racing (PathFollower script), this functions runs on loop
    /// <summary>
    /// If the nitro isn't being used, the currentNitroMeter will increase and stay at maxNitroMeter
    /// </summary>

    //On LeanFingerOld, activate this function
    public IEnumerator ActivateNitro()
    {
        while (currentNitroMeter > 0f)
        {
            _currentNitroAcceleration = nitroAcceleration;
            _usingNitro = true;
            speedParticle.Play();
            nitroFlameLeft.Play();
            nitroFlameRight.Play();

            yield return null;
        }

        yield return null;
    }

    //On LeanFingerUp, activate this function
    public void DeactivateNitro()
    {
        _currentNitroAcceleration = 0f;
        _usingNitro = false;
        speedParticle.Stop();
        nitroFlameLeft.Stop();
        nitroFlameRight.Stop();
    }

    //On LeanSwipeGearUp, activate this function
    /// <summary>
    /// Checks if current speed has reached a minimum requiered to increase gear level. If not, the current speed will be lowered but gear will increase.
    /// </summary>
    public void RaiseGear()
    {

        if (gear < 5)
        {
            gear++;
        }
        else
            return;

    }
    #endregion

    #region Private functions
    private void DepleteNitroMeter()
    {
        if (currentNitroMeter > 0f)
            currentNitroMeter -= nitroMeterConsumption;

        if (currentNitroMeter < 0f)
        {
            currentNitroMeter = 0f;
            DeactivateNitro();
        }
    }

    private void DodgeLeft()
    {
        carAnimator.Play("DodgeLeft");
        DodgeActivate();

    }

    private void DodgeRight()
    {
        carAnimator.Play("DodgeRight");
        DodgeActivate();
    }

    private void DodgeActivate()
    {
        skidMarkRight.emitting = true;
        skidMarkLeft.emitting = true;
        smokeLeft.Play();
        smokeRight.Play();
    }

    private void CollisionSlowCar()
    {
        currentSpeed = currentSpeed / 2f;
    }
    #endregion
}
