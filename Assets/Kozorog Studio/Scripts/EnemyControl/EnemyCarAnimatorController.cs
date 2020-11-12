using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarAnimatorController : MonoBehaviour
{
    public EnemyCarController enemyCarController;

    public void StopSkidMarks()
    {
        enemyCarController.skidMarkRight.emitting = false;
        enemyCarController.skidMarkLeft.emitting = false;
        enemyCarController.smokeLeft.Stop();
        enemyCarController.smokeRight.Stop();
    }
}
