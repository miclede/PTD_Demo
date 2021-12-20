namespace StateV2Example
{
    public class ExampleUnitMove : ExampleUnitState
    {
        public ExampleUnitMove(ExampleUnit unit) : base(unit)
        { }

        public override void OnEnter()
        {
            //get movement destination
            //setup to move
            //play move sound
            //start movement animation
        }

        public override void OnExit()
        {
            //cleanup from moving
            //animate move finish
            //play stopping sound
        }

        public override void Tick()
        {
            //move
        }
    }
}
