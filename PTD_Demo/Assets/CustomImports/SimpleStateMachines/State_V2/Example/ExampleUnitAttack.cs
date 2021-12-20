namespace StateV2Example
{
    public class ExampleUnitAttack : ExampleUnitState
    {
        public ExampleUnitAttack(ExampleUnit unit) : base(unit)
        { }

        public override void OnEnter()
        {
            //setup to attack
        }

        public override void OnExit()
        {
            //cleanup from attacking
        }

        public override void Tick()
        {
            //attack
        }
    }
}