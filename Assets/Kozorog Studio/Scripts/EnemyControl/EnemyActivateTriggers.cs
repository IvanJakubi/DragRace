using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivateTriggers : MonoBehaviour
{
    [SerializeField] private ScriptableEvent onEDodgeLeft;
    [SerializeField] private ScriptableEvent onEDodgeRight;
    [SerializeField] private ScriptableEvent onENitroActivated;
    [SerializeField] private ScriptableEvent onEGearUp;
    [SerializeField] private ScriptableEvent onECollision;

    [Space]
    [SerializeField] private EnemyCarController enemyCarController;
    [SerializeField] private EnemyTriggerTypeSelect enemyTriggerTypeSelected;

    private void OnTriggerEnter(Collider other)
    {
        enemyTriggerTypeSelected = other.gameObject.GetComponent<EnemyTriggerTypeSelect>();

        switch (enemyTriggerTypeSelected.enemyTriggerType)
        {
            case EnemyTriggerType.RaiseGear:
                onEGearUp.RaiseEvent(new EventMessage());
                break;
            case EnemyTriggerType.ActivateNitro:
                enemyCarController.currentNitroMeter = enemyTriggerTypeSelected.nitroFillAmount;
                onENitroActivated.RaiseEvent(new EventMessage());
                break;
            case EnemyTriggerType.Blockade:
                onECollision.RaiseEvent(new EventMessage());
                break;
            case EnemyTriggerType.ActivateDodgeLeft:
                onEDodgeLeft.RaiseEvent(new EventMessage());
                break;
            case EnemyTriggerType.ActivateDodgeRight:
                onEDodgeRight.RaiseEvent(new EventMessage());
                break;
        }
    }
}
