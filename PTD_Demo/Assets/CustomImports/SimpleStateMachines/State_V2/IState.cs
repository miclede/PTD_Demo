namespace StateV2
{
    public interface IState
    {
        //called on intervals i.e. update or coroutine
        void Tick();
        //called on enter of state
        void OnEnter();
        //called on exit of state
        void OnExit();
    }
}