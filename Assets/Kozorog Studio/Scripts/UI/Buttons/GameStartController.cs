using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStartController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ScriptableEvent _onPointerDownEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        _onPointerDownEvent.RaiseEvent(new EventMessage());
    }
}
