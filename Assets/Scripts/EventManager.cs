using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public enum EventsType
    {
        Event_PlayerDead,
        Event_PlayerPaused,
        Event_Win
    }
    
    public delegate void MethodToSuscribe(params object[] parameters);

    public static Dictionary<EventsType, MethodToSuscribe> _events;

    public static void SuscribeEvent(EventsType eventsType, MethodToSuscribe methodToSuscribe)
    {
        if(_events ==null) _events = new Dictionary<EventsType, MethodToSuscribe>();

        if (!_events.ContainsKey(eventsType))
        {
            _events.Add(eventsType, null);
        }

        _events[eventsType] += methodToSuscribe;
    }

    public static void UnsusribeEvent(EventsType eventsType, MethodToSuscribe methodToUnsuscribe)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventsType)) return;

        _events[eventsType] -= methodToUnsuscribe;
    }

    public static void TriggerEvent(EventsType eventsType, params object[] parameters)
    {
        if (_events == null) return;

        if(!_events.ContainsKey(eventsType)) return;

        if (_events[eventsType] == null) return;

        _events[eventsType](parameters);
    }
}
