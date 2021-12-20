namespace StateV2Example
{
    public class ExampleUnitIdling : ExampleUnitState
    {
        public ExampleUnitIdling(ExampleUnit unit) : base(unit)
        { }

        public override void OnEnter()
        {
            //set to not alert status
            //start idling animation
            //play idling sounds
        }

        public override void OnExit()
        {
            //cleanup idling
        }

        public override void Tick()
        {
            //idling ...
        }
    }

}
