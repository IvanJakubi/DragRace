using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticManager : MonoBehaviour
{
    [SerializeField] private OnOffButonAnimation onOffButon;

    // Start is called before the first frame update
    public void OnVibrate(EventMessage eventMessage)
    {
        if(onOffButon.isOn == true)
            Handheld.Vibrate();
    }

}
