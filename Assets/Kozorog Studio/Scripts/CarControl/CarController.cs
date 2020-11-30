using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    #region Private Variables
    private bool _usingNitro = false;
    private float _currentNitroAcceleration;
    private const float minSpeedToGear = 0.8f;

    [SerializeField] Speedometer speedometer;
    [SerializeField] ScriptableEvent onVibrate;
    #endregion

    #region Public Variables
    [Header("Speed Array")]
    [Range(0f,1f)]
    public float[] acceleration;
    public float[] maxSpeed;
    [Range(0.1f, 0.9f)]
    public float[] loseSpeedOnGear;
    [Header("Nitro Array")]
    public float[] maxSpeedNitro;
    [Range(0.5f, 2f)]
    public float nitroAcceleration;
    public float maxNitroMeter;
    [Range(0f, 1f)]
    public float nitroMeterConsumption;
    [Range(0f, 1f)]
    public float nitroMeterFill;

    [Header("Car Status")]
    [Range(0, 5)]
    public int gear;
    public float currentSpeed;
    public float currentNitroMeter;
    public bool isDodging = false;
    public bool gearRaised = false;
    public GearChangeSuccess gearChangeSuccess;

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
        if (isDodging == false)
            DodgeLeft();
    }

    public void OnDodgeRight(EventMessage eventMessage)
    {
        if (isDodging == false)
            DodgeRight();
    }

    public void OnCollisionCalled (EventMessage eventMessage)
    {
        CollisionSlowCar();
    }

    public void OnNitroFillCalled (EventMessage eventMessage)
    {
        CollisionNitroFill();
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
                currentSpeed -= acceleration[gear]*2;
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
    public void FillNitroMeter()
    {
        if (_usingNitro == false)
            currentNitroMeter += nitroMeterFill;

        if (currentNitroMeter > maxNitroMeter)
            currentNitroMeter = maxNitroMeter;
    }

    //On LeanFingerOld, activate this function
    public void ActivateNitro()
    {
        if (gearRaised == false && isDodging == false && currentNitroMeter > 0f)
        {
            _currentNitroAcceleration = nitroAcceleration;
            _usingNitro = true;
            speedParticle.Play();
            nitroFlameLeft.Play();
            nitroFlameRight.Play();
        }
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

    //On LeanFingerUp, activate this function
    public void ResetGearRaise()
    {
        gearRaised = false;
        SetGearChangeSuccess(GearChangeSuccess.Waiting);
        StartCoroutine(speedometer.GearStatus());
    }

    public void StartResetDodge()
    {
        StartCoroutine(ResetDodge());
    }

    //On LeanSwipeGearUp, activate this function
    /// <summary>
    /// Checks if current speed has reached a minimum requiered to increase gear level. If not, the current speed will be lowered but gear will increase.
    /// </summary>
    public void RaiseGear()
    {
        string currentGear = (gear+1).ToString();

        if (gear < 5 && gearRaised == false)
        {
            if (currentSpeed > maxSpeed[gear] * minSpeedToGear)
            {
                gear++;
                gearRaised = true;
                SetGearChangeSuccess(GearChangeSuccess.Perfect);
            }
            else
            {
                gear++;
                float speedToLose = currentSpeed - (currentSpeed * loseSpeedOnGear[gear]);
                currentSpeed = Mathf.Lerp(currentSpeed, speedToLose, 1f);
                gearRaised = true;
                SetGearChangeSuccess(GearChangeSuccess.Fail);
                onVibrate.RaiseEvent(new EventMessage());
            }
        }
        
        if (gear >= 5 && gearRaised == false)
        {
            gearRaised = true;
            SetGearChangeSuccess(GearChangeSuccess.Max);
        }

        StartCoroutine(speedometer.GearStatus());
        speedometer.gearText.text = currentGear;
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
        if(_usingNitro == false)
        {
            carAnimator.Play("DodgeLeft");
            DodgeActivate();
        }

    }

    private void DodgeRight()
    {
        if (_usingNitro == false)
        {
            carAnimator.Play("DodgeRight");
            DodgeActivate();
        }
    }

    private void DodgeActivate ()
    {
        isDodging = true;
        skidMarkRight.emitting = true;
        skidMarkLeft.emitting = true;
        smokeLeft.Play();
        smokeRight.Play();
    }

    private IEnumerator ResetDodge()
    {
        while (carAnimator.GetCurrentAnimatorStateInfo(0).IsName("DodgeLeft") || carAnimator.GetCurrentAnimatorStateInfo(0).IsName("DodgeRight"))
        {
            yield return null;
        }

        isDodging = false;
    }

    private void SetGearChangeSuccess (GearChangeSuccess _gearChangeSuccess)
    {
        gearChangeSuccess = _gearChangeSuccess;
    }

    private void CollisionSlowCar()
    {
        currentSpeed = currentSpeed / 2f;
    }

    private void CollisionNitroFill()
    {
        currentNitroMeter += maxNitroMeter * 0.2f;
    }
    #endregion
}
