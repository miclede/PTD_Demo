using StateV2;
using UnityEngine;

namespace PTD_Demo
{
    public class LevelEntryState : IState
    {
        private LevelDirector _levelDirector;
        private EventCatalog _eventCatalog;

        public LevelEntryState(LevelDirector director)
        {
            _levelDirector = director;
            _eventCatalog = director.levelEventCatalog;
        }

        public void OnEnter()
        {
            _eventCatalog.RaiseEventOnKey(EventType.LevelEntry);
        }

        public void OnExit() => throw new System.NotImplementedException();
        public void Tick() => throw new System.NotImplementedException();
    }
}