using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugText : MonoBehaviour
{
    public TextMeshProUGUI speedText, gearText, nitroText;

    [SerializeField] private CarController _carSpeed;

    private void Update()
    {
        speedText.SetText("Speed: " + _carSpeed.currentSpeed);
        gearText.SetText("Gear: " + _carSpeed.gear);
        nitroText.SetText("Nitro: " + _carSpeed.currentNitroMeter);
    }
}
