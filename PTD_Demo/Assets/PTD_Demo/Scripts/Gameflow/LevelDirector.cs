using UnityEngine;
using StateV2;
using System;
using System.Collections;

namespace PTD_Demo
{
    public class LevelDirector : MonoBehaviour
    {
        [SerializeField] private EventCatalog _levelEventCatalog;
        public EventCatalog levelEventCatalog => _levelEventCatalog;

        private StateMachine _levelStateMachine;

        private bool _mobsCleared;
        public void SetMobsCleared(bool set) { _mobsCleared = set; }
        private Func<bool> AreAllMobsCleared => () => _mobsCleared;

        private void Awake()
        {
            _levelStateMachine = new StateMachine();
        }

        private void Start()
        {
            ConstructStates();
        }

        private void ConstructStates()
        {
            LevelEntryState levelEntry = new LevelEntryState(this);

            _levelStateMachine.SetState(levelEntry);
        }
    }
}