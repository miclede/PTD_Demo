using System.Collections;

namespace StateV1
{
    public abstract class State
    {
        protected Name.NAMESystem gameFlowSystem;

        public State(Name.NAMESystem gameFlow)
        {
            gameFlowSystem = gameFlow;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

    }
}