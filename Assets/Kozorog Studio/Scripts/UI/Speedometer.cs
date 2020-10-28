using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
    private const float _maxSpeedAngle = -75;
    private const float _minSpeedAngle = 60;

    [SerializeField] private GameObject gearIcon;
    [SerializeField] private CarController carController;

    public Transform pointerTransform;
    public TextMeshProUGUI gearText;
    public Image RPMImage;
    public Image NitroImage;

    // Update is called once per frame
    void Update()
    {
        pointerTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        RPMImage.fillAmount = GetRPMFill();
        NitroImage.fillAmount = GetNitroFill();
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = _minSpeedAngle - _maxSpeedAngle;

        float speedNormalized = carController.currentSpeed / carController.maxSpeedNitro[5];

        return _minSpeedAngle - speedNormalized * totalAngleSize;
    }

    private float GetRPMFill()
    {
        float RPMNormalized = carController.currentSpeed / carController.maxSpeed[carController.gear];

        return RPMNormalized;
    }

    private float GetNitroFill()
    {
        float nitroNormalized = carController.currentNitroMeter / carController.maxNitroMeter;

        return nitroNormalized;
    }

    public IEnumerator ShakeGear()
    {
        iTween.ShakePosition(gearIcon, iTween.Hash("x", 3f, "time", 0.5f, "delay", 0f));

        yield return null;
    }
}
