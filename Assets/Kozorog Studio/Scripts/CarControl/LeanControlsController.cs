using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanControlsController : MonoBehaviour
{
    [SerializeField] private GameObject gameControls;

    public void OnEndReached(EventMessage eventMessage)
    {
        gameControls.SetActive(false);
    }

    public void OnGameStart(EventMessage eventMessage)
    {
        gameControls.SetActive(true);
    }
}
