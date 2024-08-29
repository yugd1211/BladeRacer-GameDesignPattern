using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using EventBus;
using UnityEngine;
using UnityEngine.Events;

public class RaceEventBus
{
    private static readonly Dictionary<RaceEventType, UnityEvent> Events =
        new Dictionary<RaceEventType, UnityEvent>();

    public static void Subscribe(RaceEventType type, UnityAction listener)
    {
        if (!Events.TryGetValue(type, out UnityEvent thisEvent))
        {
            thisEvent = new UnityEvent();
            Events.Add(type, thisEvent);
        }
        thisEvent.AddListener(listener);
    }
    
    public static void Unsubscribe(RaceEventType type, UnityAction listener)
    {
        if (!Events.TryGetValue(type, out UnityEvent thisEvent))
            return;
        thisEvent.RemoveListener(listener);
    }
    
    public static void Publish(RaceEventType type)
    {
        if (!Events.TryGetValue(type, out UnityEvent thisEvent))
            return;
        thisEvent.Invoke();
    }
    
}
