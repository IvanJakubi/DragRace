using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckInternet : MonoBehaviour
{
    public bool connectionAvaliable;

    private void StartCheckingConnection(EventMessage eventMessage)
    {
        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
                connectionAvaliable = true;
            else
                connectionAvaliable = false;
        }));
    }

    IEnumerator CheckInternetConnection (Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();

        if (request.error != null)
            action(false);
        else
            action(true);
    }
}
