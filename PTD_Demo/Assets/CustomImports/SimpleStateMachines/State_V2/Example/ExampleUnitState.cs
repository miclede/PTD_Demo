using StateV2;

namespace StateV2Example
{
    public abstract class ExampleUnitState : IState
    {
        //store unit passed in through constructor
        protected ExampleUnit _myUnit;

        //constructor used to pass in the unit for use in inheriting states
        public ExampleUnitState(ExampleUnit unit) => _myUnit = unit;

        //implement the interface
        public virtual void OnEnter() => throw new System.NotImplementedException();
        public virtual void OnExit() => throw new System.NotImplementedException();
        public virtual void Tick() => throw new System.NotImplementedException();
    }
}
