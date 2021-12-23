using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "EventCatalog", menuName = "Events/Catalog")]
    public class EventCatalog : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<EventType, GameEvent> _levelEvents = new Dictionary<EventType, GameEvent>();
        public Dictionary<EventType, GameEvent> levelEvents => _levelEvents;

        public void RaiseEventOnKey(EventType key) => _levelEvents[key].Raise();
    }

    public enum EventType
    {
        LevelEntry
    }
}