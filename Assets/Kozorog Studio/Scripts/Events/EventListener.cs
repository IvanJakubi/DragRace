using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    #region Private variables
    [SerializeField] private List<EventListenerStruct> _eventListenerStructs;
    #endregion

    #region Properties
    public List<EventListenerStruct> EventListenerStructs { get => _eventListenerStructs; }
    #endregion

    #region Unity event functions
    private void OnEnable()
    {
        foreach(var messageEvent in _eventListenerStructs)
        {
            if(messageEvent.ScriptableEvent != null)
            {
                messageEvent.ScriptableEvent.AddListener(this);
            }
        }
    }

    private void OnDisable()
    {
        foreach (EventListenerStruct messageEvent in _eventListenerStructs)
        {
            if (messageEvent.ScriptableEvent != null)
            {
                messageEvent.ScriptableEvent.RemoveListener(this);
            }
        }            
    }
    #endregion
}

[System.Serializable]
public struct EventListenerStruct
{
    #region Private variables
    [SerializeField] ScriptableEvent _scriptableEvent;
    [SerializeField] MessageUnityEvent _messageUnityEvent;
    #endregion

    #region Properties
    public ScriptableEvent ScriptableEvent { get => _scriptableEvent; }
    public MessageUnityEvent MessageUnityEvent { get => _messageUnityEvent; }
    #endregion
}

[System.Serializable]
public class MessageUnityEvent : UnityEvent<EventMessage> { }