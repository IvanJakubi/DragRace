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

    public IEnumerator GearStatus()
    {
        switch (carController.gearChangeSuccess)
        {
            case CarController.GearChangeSuccess.Max:
                //iTween.ShakePosition(gearIcon, iTween.Hash("x", 3f, "y", 3f, "time", 0.5f, "delay", 0f));
                break;
            case CarController.GearChangeSuccess.Perfect:
                gearIcon.GetComponent<Image>().color = Color.green;
                break;
            case CarController.GearChangeSuccess.Fail:
                gearIcon.GetComponent<Image>().color = Color.red;
                break;
            case CarController.GearChangeSuccess.Waiting:
                yield return new WaitForSeconds(0.3f);
                gearIcon.GetComponent<Image>().color = new Color(0, 206, 211);
                break;
        }

        yield return null;
    }
}
