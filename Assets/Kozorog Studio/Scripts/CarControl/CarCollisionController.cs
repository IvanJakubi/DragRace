using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionController : MonoBehaviour
{
    [SerializeField] private ScriptableEvent collisionSlowDownEvent;
    [SerializeField] private ScriptableEvent collisionNitroFill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blockade")
        {
            collisionSlowDownEvent.RaiseEvent(new EventMessage());
        }

        if (other.gameObject.tag == "Nitro")
        {
            collisionNitroFill.RaiseEvent(new EventMessage());
        }
    }
}
