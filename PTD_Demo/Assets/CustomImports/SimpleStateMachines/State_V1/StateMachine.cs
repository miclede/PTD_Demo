using UnityEngine;

namespace StateV1
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State state;

        public void SetState(State toState)
        {
            state = toState;
            StartCoroutine(state.Start());
        }
    }
}