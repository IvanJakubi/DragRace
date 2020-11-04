using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for event messages.
/// </summary>
[CreateAssetMenu(fileName = "EventMessage", menuName = "KozorogStudio/EventMessages/EmptyMessage")]
public class EventMessage : ScriptableObject
{    
}

/// <summary>
/// Event message that holds an integer value.
/// </summary>
[CreateAssetMenu(fileName = "EventMessage", menuName = "KozorogStudio/EventMessages/IntMessage")]
public class IntMessage : EventMessage
{
    public int IntValue;

    public IntMessage(int value)
    {
        IntValue = value;
    }
}

/// <summary>
/// Event message that holds a float value.
/// </summary>
[CreateAssetMenu(fileName = "EventMessage", menuName = "KozorogStudio/EventMessages/FloatMessage")]
public class FloatMessage : EventMessage
{
    public float FloatValue;

    public FloatMessage(float value)
    {
        FloatValue = value;
    }
}

/// <summary>
/// Event message that holds a string value;
/// </summary>
[CreateAssetMenu(fileName = "EventMessage", menuName = "KozorogStudio/EventMessages/StringMessage")]
public class StringMessage : EventMessage
{
    public string StringValue;

    public StringMessage(string value)
    {
        StringValue = value;
    }
}

/// <summary>
/// Event message that holds a Vector3 value.
/// </summary>
[CreateAssetMenu(fileName = "EventMessage", menuName = "KozorogStudio/EventMessages/Vector3Message")]
public class Vector3Message : EventMessage
{
    public Vector3 Vector3Value;

    public Vector3Message(Vector3 vector3)
    {
        Vector3Value = vector3;
    }
}
