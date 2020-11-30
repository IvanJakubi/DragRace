using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarEnginePitchController : MonoBehaviour
{
    public AudioSource carEnginePitch;

    [SerializeField] CarController carController;

    
   [SerializeField] private float pitch;

    // Update is called once per frame
    void Update()
    {
        pitch = carController.currentSpeed / carController.maxSpeed[carController.gear];
        carEnginePitch.pitch = pitch;
    }
}
