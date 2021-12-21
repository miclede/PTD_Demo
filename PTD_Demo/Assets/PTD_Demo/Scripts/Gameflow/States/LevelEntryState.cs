using StateV2;
using UnityEngine;

namespace PTD_Demo
{
    public class LevelEntryState : IState
    {
        private LevelDirector _levelDirector;
        public LevelEntryState(LevelDirector director) => _levelDirector = director;

        public void OnEnter() => throw new System.NotImplementedException();
        public void OnExit() => throw new System.NotImplementedException();
        public void Tick() => throw new System.NotImplementedException();
    }
}