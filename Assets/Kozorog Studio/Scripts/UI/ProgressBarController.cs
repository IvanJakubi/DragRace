using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Image progressFill;
    [SerializeField] private PathFollower pathFollower;

    // Update is called once per frame
    void Update()
    {
        progressFill.fillAmount = pathFollower._dstTravelled / pathFollower.pathLength;
    }
}
