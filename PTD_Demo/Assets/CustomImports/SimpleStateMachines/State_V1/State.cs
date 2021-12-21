using System.Collections;

namespace StateV1
{
    public abstract class State
    {
        protected PTD_Demo.PTDSystem gameFlowSystem;

        public State(PTD_Demo.PTDSystem gameFlow)
        {
            gameFlowSystem = gameFlow;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

    }
}